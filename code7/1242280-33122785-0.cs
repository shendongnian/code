    public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<IMyManager, MyManager>();
            MvcUnityContainer.Container = container;
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
