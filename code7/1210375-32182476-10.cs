    using System;
    using Ninject;
    using DI;
    using DI.Ninject;
    using DI.Ninject.Modules;
    internal class CompositionRoot
    {
        public static void Compose()
        {
            // Create the DI container
            var container = new StandardKernel();
            // Setup configuration of DI
            container.Load(new MyNinjectModule());
            // Register our ControllerFactory with MVC
			ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(container));
        }
    }
