    [MyResponseFilter]
    public class SomeService : Service 
    {
        public string[] CacheMemory { get; set; }
 
        public object Any(Request request)
        {
            base.Request.Items["CacheMemory"] = CacheMemory;
            //...
            return response;
        }
    }
    public class MyResponseFilterAttribute : ResponseFilterAttribute 
    {
        public override void Execute(IRequest req, IResponse res, object dto) 
        {
            var cacheMemory = (string[])req.Items["CacheMemory"];
        }
    }
