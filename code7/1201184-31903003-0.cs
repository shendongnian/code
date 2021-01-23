            services.ConfigureMvcJson(o =>
            {
                o.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                o.SerializerSettings.DefaultValueHandling = DefaultValueHandling.Ignore;
                o.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            });
