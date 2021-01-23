    public class ProviderFactory : IFactory
    {
        public IProvider GetProvider()
        {
            return new Provider();
        }
    }
