    using System;
    using System.Linq;
    using System.Reflection;
    using AutoMapper;
    using TreasuryRecords.Requests.Authenticate.Login;
    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            Assembly
                .GetExecutingAssembly()
                .RegisterConfigurations();
            typeof(LoginRequest)
                .Assembly
                .RegisterConfigurations();
        }
        public static void RegisterConfigurations(this Assembly assembly)
        {
            var types = assembly.GetTypes();
            var automapperProfiles = types
                                        .Where(x => typeof(Profile).IsAssignableFrom(x))
                                        .Select(Activator.CreateInstance)
                                        .OfType<Profile>()
                                        .ToList();
              
            // so here you can pass in the instance of mapper
            // I just use the static for ease
            automapperProfiles.ForEach(Mapper.Configuration.AddProfile);
        }
    }
