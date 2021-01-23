    public static class FooFactory
    {
        public static IFoo GetInstance(IServiceFactory serviceFactory, int value)
        {
            switch (value)
            {
                case 1:
                {
                    return serviceFactory.GetInstance<Foo>();
                }
                case 2:
                {
                    return serviceFactory.GetInstance<FooThatImplementsIFoo>();
                }
                case 3:
                {
                    return serviceFactory.GetInstance<AnotherFooThatImplementsIFoo>();
                }
                default:
                {
                    return null;
                }
            }
        }
    }
