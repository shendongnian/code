    namespace SInnovations.Azure.ServiceFabric.Unity.Actors
    {
        using Microsoft.Practices.Unity;
        using SInnovations.Azure.ServiceFabric.Unity.Abstraction;
    
        public class OnActorDeactivateInterceptor : IActorDeactivationInterception
        {
            private readonly IUnityContainer container;
            public OnActorDeactivateInterceptor(IUnityContainer container)
            {
                this.container = container;
            }
    
            public void Intercept()
            {
                this.container.Dispose();
            }
        }
    }
