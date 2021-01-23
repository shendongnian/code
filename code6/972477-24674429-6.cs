    public partial class MyModelContainer
    {
        public void OnContextCreated()
        {
            this.ContextOptions.ProxyCreationEnabled = false;
        }
    }
