    public class WcfServiceHostBuildPlanPolicy<TInterface, TImplementation> : IBuildPlanPolicy
        where TInterface : class
        where TImplementation : class, TInterface
    {
        private class ServiceEndpoint
        {
            public string Address { get; set; }
            public Binding Binding { get; set; }
            public Type Type { get; set; }
        }
        private readonly List<ServiceEndpoint> endpoints;
        private readonly List<Type> behaviors;
        /// <summary>
        /// Adds a new service behavior.
        /// </summary>
        public void AddBehavior<T>() where T : IServiceBehavior
        {
            behaviors.Add(typeof (T));
        }
        public void AddServiceEndpoint(Type type, string address, Binding binding)
        {
            endpoints.Add(new ServiceEndpoint
            {
                Address = address,
                Binding = binding,
                Type = type
            });
        }
        public WcfServiceHostBuildPlanPolicy()
        {
            m_Behaviors = new List<Type>();
            m_Endpoints = new List<ServiceEndpoint>();
        }
        public void BuildUp(IBuilderContext context)
        {
            if (context.Existing == null)
            {
                // build up dependencies
                var behavior = context.NewBuildUp<DIServiceBehavior<TInterface, TImplementation>>();
                // create new DIServiceHost
                var serviceHost = new DIServiceHost<TInterface, TImplementation>(behavior);
                // add behaviors to ServiceHost
                foreach (var behaviorType in behaviors)
                {
                    var newBehavior = context.NewBuildUp(new NamedTypeBuildKey(behaviorType)) as IServiceBehavior;
                    serviceHost.Description.Behaviors.Add(newBehavior);
                }
                // add service endpoints to ServiceHost
                endpoints.ForEach(s => serviceHost.AddServiceEndpoint(s.Type, s.Binding, s.Address));
                context.Existing = serviceHost;
            }
        }
    }
