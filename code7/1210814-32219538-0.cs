        private void RegisterServices()
        {
            Container container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            Registration registration = WebRequestLifestyle.Scoped.CreateRegistration<MyDBContext>(container);
            container.AddRegistration(typeof(ITaxonomyDBContext), registration);
            container.AddRegistration(typeof(INavigationDBContext), registration);
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
            container.Verify();
        }
