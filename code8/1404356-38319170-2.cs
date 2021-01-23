    public class MyClass {
        protected IHostingEnvironment HostingEnvironment { get;private set; }
    
        public MyClass(IHostingEnvironment host) {
            HostingEnvironment = host;
        }
    }
