    // registration, probably in bootstrapper or module initializer
    _unityContainer.RegisterType<Person>( new ContainerControlledLifetimeManager() )
    // usage
    class PersonConsumer
    {
        public PersonConsumer( Person theStaticPerson )
        {
            // theStaticPerson is always the same instance
            // you can use it now or store it in a private field for later
        }
    }
