       container.RegisterType<MessageContext>(
            new InjectionFactory( c =>
                 new MessageContext(
                       new DatabaseRepository<Message>(
                             new RepositoryConfig(){AutoDetectionEnabled = false} ) ) );
