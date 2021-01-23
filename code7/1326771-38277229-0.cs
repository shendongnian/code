    services.AddMvc()
            .AddJsonOptions(opt =>
        {
            var resolver  = opt.SerializerSettings.ContractResolver;
            if (resolver != null)
            {
                var res = resolver as DefaultContractResolver;
                res.NamingStrategy = null;  // <<!-- this removes the camelcasing
            }
        });
