    using System.Reflection;
    using System.Web.Http;
    using System.Web.Http.Dependencies;
    using Ninject.Syntax;
    
    [assembly: WebActivatorEx.PreApplicationStartMethod(typeof(YourProject.App_Start.NinjectWebCommon), "Start")]
    [assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(YourProject.App_Start.NinjectWebCommon), "Stop")]
    
    namespace YourProject.Web.UI.App_Start
    {
        using System;
        using System.Web;
        using Microsoft.Web.Infrastructure.DynamicModuleHelper;
        using Ninject;
        using Ninject.Web.Common;
    
        public class NinjectDependencyScope : IDependencyScope
        {
            IResolutionRoot resolver;
    
            public NinjectDependencyScope(IResolutionRoot resolver)
            {
                this.resolver = resolver;
            }
    
            public object GetService(Type serviceType)
            {
                if (resolver == null)
                    throw new ObjectDisposedException("this", "This scope has been disposed");
    
                return resolver.TryGet(serviceType);
            }
    
            public System.Collections.Generic.IEnumerable<object> GetServices(Type serviceType)
            {
                if (resolver == null)
                    throw new ObjectDisposedException("this", "This scope has been disposed");
    
                return resolver.GetAll(serviceType);
            }
    
            public void Dispose()
            {
                IDisposable disposable = resolver as IDisposable;
                if (disposable != null)
                    disposable.Dispose();
    
                resolver = null;
            }
        }
    
        // This class is the resolver, but it is also the global scope
        // so we derive from NinjectScope.
        public class NinjectDependencyResolver : NinjectDependencyScope, IDependencyResolver
        {
            IKernel kernel;
    
            public NinjectDependencyResolver(IKernel kernel)
                : base(kernel)
            {
                this.kernel = kernel;
            }
    
            public IDependencyScope BeginScope()
            {
                return new NinjectDependencyScope(kernel.BeginBlock());
            }
        }
    
        public static class NinjectWebCommon 
        {
            private static readonly Bootstrapper bootstrapper = new Bootstrapper();
    
            /// <summary>
            /// Starts the application
            /// </summary>
            public static void Start() 
            {
                DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
                DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
                bootstrapper.Initialize(CreateKernel);
            }
            
            /// <summary>
            /// Stops the application.
            /// </summary>
            public static void Stop()
            {
                bootstrapper.ShutDown();
            }
            
            /// <summary>
            /// Creates the kernel that will manage your application.
            /// </summary>
            /// <returns>The created kernel.</returns>
            private static IKernel CreateKernel()
            {
                var kernel = new StandardKernel();
                try
                {
                    kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                    kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
    
                    RegisterServices(kernel);
    
                    // Install our Ninject-based IDependencyResolver into the Web API config
                    GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);
    
                    WebApiApplication.Kernel = kernel;
                    return kernel;
                }
                catch
                {
                    kernel.Dispose();
                    throw;
                }
            }
    
            /// <summary>
            /// Load your modules or register your services here!
            /// </summary>
            /// <param name="kernel">The kernel.</param>
            private static void RegisterServices(IKernel kernel)
            {
                kernel.Load(Assembly.GetExecutingAssembly());
            }        
        }
    }
