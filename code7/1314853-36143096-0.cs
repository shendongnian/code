    using System;
    using System.Linq;
    using System.Reflection;
    //
    using AutoMapper;
    //
    using SimpleInjector;
    using SimpleInjector.Packaging;
    public class AutoMapperPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            var profiles = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(x => typeof(AutoMapper.Profile).IsAssignableFrom(x));
            var config = new MapperConfiguration(cfg =>
            {
                foreach (var profile in profiles)
                {
                    cfg.AddProfile(Activator.CreateInstance(profile) as AutoMapper.Profile);
                }
            });
            container.RegisterSingleton<MapperConfiguration>(config);
            container.Register<IMapper>(() => config.CreateMapper(container.GetInstance));
        }
    }
