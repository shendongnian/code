    namespace SInnovations.Azure.ServiceFabric.Unity
    {
        using System;
        using System.Fabric;
        using Microsoft.Practices.Unity;
        using Microsoft.ServiceFabric.Actors;
        using SInnovations.Azure.ServiceFabric.Unity.Abstraction;
        using SInnovations.Azure.ServiceFabric.Unity.Actors;
    
        public static class UnityFabricExtensions
        {
            public static IUnityContainer WithFabricContainer(this IUnityContainer container)
            {
                return container.WithFabricContainer(c => FabricRuntime.Create());
            }
            public static IUnityContainer WithFabricContainer(this IUnityContainer container, Func<IUnityContainer,FabricRuntime> factory)
            {
                container.RegisterType<FabricRuntime>(new ContainerControlledLifetimeManager(), new InjectionFactory(factory));
                return container;
            }
    
            public static IUnityContainer WithActor<TActor>(this IUnityContainer container) where TActor : ActorBase
            {
                if (!container.IsRegistered<IActorDeactivationInterception>())
                {
                    container.RegisterType<IActorDeactivationInterception, OnActorDeactivateInterceptor>(new HierarchicalLifetimeManager());
                }
    
                container.RegisterType(typeof(TActor), ActorProxyTypeFactory.CreateType<TActor>(),new HierarchicalLifetimeManager());
                container.Resolve<FabricRuntime>().RegisterActorFactory(() => {
                    try {
                        var actor = container.CreateChildContainer().Resolve<TActor>();
                        return actor;
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                    });
    
                return container;
            }
           
           
            public static IUnityContainer WithStatelessFactory<TFactory>(this IUnityContainer container, string serviceTypeName) where TFactory : IStatelessServiceFactory
            {
                if (!container.IsRegistered<TFactory>())
                {
                    container.RegisterType<TFactory>(new ContainerControlledLifetimeManager());
                }
                container.Resolve<FabricRuntime>().RegisterStatelessServiceFactory(serviceTypeName, container.Resolve<TFactory>());
                return container;
            }
            public static IUnityContainer WithStatefulFactory<TFactory>(this IUnityContainer container, string serviceTypeName) where TFactory : IStatefulServiceFactory
            {
                if (!container.IsRegistered<TFactory>())
                {
                    container.RegisterType<TFactory>(new ContainerControlledLifetimeManager());
                }
                container.Resolve<FabricRuntime>().RegisterStatefulServiceFactory(serviceTypeName, container.Resolve<TFactory>());
                return container;
            }
            public static IUnityContainer WithService<TService>(this IUnityContainer container, string serviceTypeName) 
            {
                container.Resolve<FabricRuntime>().RegisterServiceType(serviceTypeName, typeof(TService));
                return container;
            }
        }
    }
