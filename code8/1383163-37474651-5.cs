    public class MyServices : Service
    {
        public IGetContextItems ContextItems { get; set; }
        public object Get(Request request)
        {
           return ContextItems.Get(base.Request, request.Id);
        }
    }
