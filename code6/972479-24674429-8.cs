    public partial class MyModelContainer
    {
        public void OnContextCreated()
        {
            this.Configuration.ContextOptions.ProxyCreationEnabled = false;
        }
    }
