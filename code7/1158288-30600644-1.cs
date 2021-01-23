    public static class ContainerExtensions
    {
        public static IEnumerable<InstanceProducer> GetInstanceProducers(this Container container)
        {
            return container.GetCurrentRegistrations()
                .SelectMany(x => GetInstanceProducers(container, x));
        }
        private static IEnumerable<InstanceProducer> GetInstanceProducers(Container container, InstanceProducer instanceProducer)
        {
            yield return instanceProducer;
            var producers = from ctor in instanceProducer.Registration
                                .ImplementationType.GetConstructors()
                            from param in ctor.GetParameters()
                            from producer in GetInstanceProducers(
                                container,
                                container.GetRegistration(param.ParameterType))
                            select producer;
            foreach (var producer in producers)
                yield return producer;
        }
    }
