    public class ContainerAdapter
    {
        public int Age { get; set; }
            public string Name { get; set; }
            public int Id { get; set; }
            public void HelloWorld()
            {
                //
            }
            private string GetHelloWorld()
            {
                return "";
                //
            }
        private static ContainerAdapter instance = null;
      
        // Lock synchronization object
        private static object syncLock = new object();
        public static ContainerAdapter Instance
        {
            get
            {
                lock (syncLock)
                {
                    if (ContainerAdapter.instance == null)
                        ContainerAdapter.instance = new ContainerAdapter();
                    return ContainerAdapter.instance;
                }
            }
        }
    }
