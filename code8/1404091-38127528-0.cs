        /// <summary>
        /// The Web api config.
        /// </summary>
        public class WebApiConfig
        {
            /// <summary>
            /// Registers the specified configuration.
            /// </summary>
            /// <param name="config">The configuration.</param>
            public static void Register(HttpConfiguration config)
            {
    config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
    
                var settings = config.Formatters.JsonFormatter.SerializerSettings;
    
                settings.Formatting = Formatting.None;
                settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                settings.NullValueHandling = NullValueHandling.Ignore;
                settings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
                settings.DateParseHandling = DateParseHandling.DateTimeOffset;
                settings.Converters.Add(new OptionalJsonConverter());
