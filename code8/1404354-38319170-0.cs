    public class MyClass {
        protected static IHostingEnvironment HostingEnvironment { get;private set; }
    
        public MyClass(IHostingEnvironment host) {
            HostingEnvironment = host;
        }
    }
