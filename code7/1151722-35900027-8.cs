    namespace SInnovations.Azure.ServiceFabric.Unity.Abstraction
    {
        /// <summary>
        /// The <see cref="IActorDeactivationInterception"/> interface for defining an OnDeactivateInterception
        /// </summary>
        public interface IActorDeactivationInterception
        {
            void Intercept();
        }
    }
