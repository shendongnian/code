    class ChildClient : BaseClient
    {
        public ChildClient(string host, string port) : base(host, port)
        {
        }
        public bool connect()
        {
            this.Open();
           
            return this.Authenticate();
        }
        public void disconnect()
        {
            this.Close();
        }
    }
