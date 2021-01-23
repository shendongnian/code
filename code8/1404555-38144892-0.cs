     services.AddMvc()
                   .AddJsonOptions(options =>
                   {
                       options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver();
                   });
