       using Newtonsoft.Json.Converters;
        
     services
        .AddMvc(options =>
        {
         options.EnableEndpointRouting = false;
         })
        .AddNewtonsoftJson(options => options.SerializerSettings.Converters.Add(new StringEnumConverter()))
