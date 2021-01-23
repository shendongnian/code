    public class UserController
    {
        private readonly IHandler handler;
        public UserController(IHandler handler)
        {
            if (handler == null) throw new NullReferenceException(nameof(handler));
            
            this.handler = handler; 
        }
        // ...
        public ActionResult Save(string id)
        { 
            handler(id);
        }
    }
