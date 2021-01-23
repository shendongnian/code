    public interface INotificationHandler
    {
        Task<object> Handle(string msg);
    }
    
    public abstract BaseHandler<T> : INotificationHandler
    {
        Task<object> INotificationHandler.Handle(string msg)
        {
            return Handle(msg);
        }
    
        public abstract Task<T> Handle(string msg);
    }
    
    public class FooHandler : BaseHandler<Foo>
    {
        public override Task<Foo> Handle(string msg) { return Task.FromResult<Foo>(new Foo()); }
    }
    
    public class BarHandler : BaseHandler<Bar>
    {
        public override Task<Bar> Handle(string msg) { return Task.FromResult<Bar>(new Bar()); }
    }
    
    var notificationHandlers = new Dictionary<string, INotificationHandler>();
    notificationHandlers["foo"] = new FooHandler();
    notificationHandlers["bar"] = new BarHandler();
    ...
    public void MessageReceived(string type, string msg)
    {
        INotificationHandler handler = notificationHandlers[type];
        handler.Notify(msg).ContinueWith((result) => /* do stuff with a plain object */)
    }
