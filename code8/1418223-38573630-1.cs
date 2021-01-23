    public class MyServices : Service
    {
        public IServerEvents ServerEvents { get; set; }
    
        public object Any(Request request)
        {
            ServerEvents.NotifyAll("cmd.mybroadcast", request);
            ...
        }
    }
