    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
        public class MyServiceWrapper : IMyServiceWrapper
        {
            // get the underlying service from the container
            private static IMyService myService = new MyService();
    
    
            public MyServiceWrapper()
            {
                // parameterless constructor which does nothing, so easy to constructor
            }
            public void DoSomething()
            {
                myService.DoSomething();
            }
        }
    
        // dummy interface to ensure the wrapper has the same methods as the underlying service
        // but helps to avoid confusion
        public interface IMyServiceWrapper : IMyService
        {
        }
