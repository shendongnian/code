    public class StuffService : ServiceStack.Service
    {
        public IStuffHandler Handler { get; set; }
    
        public void Post(RequestMessage message)
        {
            Handler.HandleIt();
        }
    }
