        public static void RegisterComponents()
        {
            var builder = new ContainerBuilder();
            //First register the NotificationDataProvider
            builder.RegisterType<NotificationUpdateDataProvider>()
                .As<INotificationUpdateDataProvider>();
            //Register the update service
            builder.RegisterType<NotificationUpdateService>()
                .As<INotificationUpdateService>();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
