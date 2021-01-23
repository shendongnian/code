        public void ConfigureServices(IServiceCollection services)
        {
           services.AddMvc();
           var serviceDescriptor = services.FirstOrDefault(s => s.ServiceType.FullName.Contains("IControllerFactory"));
           var serviceIndex = services.IndexOf(serviceDescriptor);
           services.Insert(serviceIndex, new ServiceDescriptor(typeof(IControllerFactory), typeof(CustomControllerFactory), ServiceLifeTime.Singleton));
           services.RemoveAt(serviceIndex + 1);
        }
