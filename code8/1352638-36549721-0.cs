    // Null Object pattern
    public sealed class EmptyRestClient : IRestClient {
        // Implement IRestClient methods to do nothing.
    }
    // Register in StructureMap
    container.For<IRestClient>().Use(new EmptyRestClient());
