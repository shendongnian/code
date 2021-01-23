    public class MergeContainerExtension : UnityContainerExtension
    {
        private readonly IUnityContainer[] containers;
        public MergeContainerExtension(params IUnityContainer[] containers)
        {
            this.containers = containers;
        }
        protected override void Initialize()
        {
            foreach (var container in containers)
            {
                foreach (var registration in container.Registrations)
                {
                    base.Container.
                        RegisterType(
                        registration.RegisteredType, 
                        registration.MappedToType,
                        registration.Name,
                        registration.LifetimeManager);
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            UnityContainer aContainer = new UnityContainer();
            UnityContainer bContainer = new UnityContainer();
            UnityContainer container = new UnityContainer();
            MergeContainerExtension mergeExtension = new MergeContainerExtension(aContainer, bContainer);
            container.AddExtension(mergeExtension);
            var resolve = container.Resolve<IClassA>();
        }
    }
