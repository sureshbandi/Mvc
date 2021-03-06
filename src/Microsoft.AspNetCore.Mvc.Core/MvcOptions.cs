// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Microsoft.AspNetCore.Mvc
{
    /// <summary>
    /// Provides programmatic configuration for the MVC framework.
    /// </summary>
    public class MvcOptions
    {
        private int _maxModelStateErrors = ModelStateDictionary.DefaultMaxAllowedErrors;

        public MvcOptions()
        {
            CacheProfiles = new Dictionary<string, CacheProfile>(StringComparer.OrdinalIgnoreCase);
            Conventions = new List<IApplicationModelConvention>();
            Filters = new FilterCollection();
            FormatterMappings = new FormatterMappings();
            InputFormatters = new FormatterCollection<IInputFormatter>();
            OutputFormatters = new FormatterCollection<IOutputFormatter>();
            ModelBinderProviders = new List<IModelBinderProvider>();
            ModelBindingMessageProvider = new ModelBindingMessageProvider();
            ModelMetadataDetailsProviders = new List<IMetadataDetailsProvider>();
            ModelValidatorProviders = new List<IModelValidatorProvider>();
            ValueProviderFactories = new List<IValueProviderFactory>();
        }

        /// <summary>
        /// Gets a Dictionary of CacheProfile Names, <see cref="CacheProfile"/> which are pre-defined settings for
        /// response caching.
        /// </summary>
        public IDictionary<string, CacheProfile> CacheProfiles { get; }

        /// <summary>
        /// Gets a list of <see cref="IApplicationModelConvention"/> instances that will be applied to
        /// the <see cref="ApplicationModel"/> when discovering actions.
        /// </summary>
        public IList<IApplicationModelConvention> Conventions { get; }

        /// <summary>
        /// Gets a collection of <see cref="IFilterMetadata"/> which are used to construct filters that
        /// apply to all actions.
        /// </summary>
        public FilterCollection Filters { get; }

        /// <summary>
        /// Used to specify mapping between the URL Format and corresponding media type.
        /// </summary>
        public FormatterMappings FormatterMappings { get; }

        /// <summary>
        /// Gets a list of <see cref="IInputFormatter"/>s that are used by this application.
        /// </summary>
        public FormatterCollection<IInputFormatter> InputFormatters { get; }

        /// <summary>
        /// Gets or sets the maximum number of validation errors that are allowed by this application before further
        /// errors are ignored.
        /// </summary>
        public int MaxModelValidationErrors
        {
            get { return _maxModelStateErrors; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                _maxModelStateErrors = value;
            }
        }

        /// <summary>
        /// Gets a list of <see cref="IModelBinderProvider"/>s used by this application.
        /// </summary>
        public IList<IModelBinderProvider> ModelBinderProviders { get; }

        /// <summary>
        /// Gets the default <see cref="IModelBindingMessageProvider"/>. Changes here are copied to the
        /// <see cref="ModelMetadata.ModelBindingMessageProvider"/> property of all <see cref="ModelMetadata"/>
        /// instances unless overridden in a custom <see cref="IBindingMetadataProvider"/>.
        /// </summary>
        public ModelBindingMessageProvider ModelBindingMessageProvider { get; }

        /// <summary>
        /// Gets a list of <see cref="IMetadataDetailsProvider"/> instances that will be used to
        /// create <see cref="ModelMetadata"/> instances.
        /// </summary>
        /// <remarks>
        /// A provider should implement one or more of the following interfaces, depending on what
        /// kind of details are provided:
        /// <ul>
        /// <li><see cref="IBindingMetadataProvider"/></li>
        /// <li><see cref="IDisplayMetadataProvider"/></li>
        /// <li><see cref="IValidationMetadataProvider"/></li>
        /// </ul>
        /// </remarks>
        public IList<IMetadataDetailsProvider> ModelMetadataDetailsProviders { get; }

        /// <summary>
        /// Gets a list of <see cref="IModelValidatorProvider"/>s used by this application.
        /// </summary>
        public IList<IModelValidatorProvider> ModelValidatorProviders { get; }

        /// <summary>
        /// Gets a list of <see cref="IOutputFormatter"/>s that are used by this application.
        /// </summary>
        public FormatterCollection<IOutputFormatter> OutputFormatters { get; }

        /// <summary>
        /// Gets or sets the flag which causes content negotiation to ignore Accept header
        /// when it contains the media type */*. <see langword="false"/> by default.
        /// </summary>
        public bool RespectBrowserAcceptHeader { get; set; }

        /// <summary>
        /// Gets a list of <see cref="IValueProviderFactory"/> used by this application.
        /// </summary>
        public IList<IValueProviderFactory> ValueProviderFactories { get; }

        /// <summary>
        /// Gets or sets the SSL port that is used by this application when <see cref="RequireHttpsAttribute"/>
        /// is used. If not set the port won't be specified in the secured URL e.g. https://localhost/path.
        /// </summary>
        public int? SslPort { get; set; }
    }
}