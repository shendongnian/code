    class Client : IClient
    {
        public IClientConfiguration Configuration { get; set; }
        // Explicit implementation
        IConfiguration IEntity.Configuration 
        { 
            get { return this.Configuration; }
            set { /* what to do here? */ }
        }
    }
