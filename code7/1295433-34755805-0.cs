    class ServiceFactory : IServiceFactory
    {
        public IService GetService(string customer)
        {
            switch (customer)
            {
                case "special":
                    return container.Resolve<IService>("special");
                default:
                    return container.Resolve<IService>("default");
            }
        }
    }
