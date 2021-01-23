    public class DerivedClient : Client, IClient
    {
        public DerivedClient(string portNum)
            : base(portNum) {}
    }
