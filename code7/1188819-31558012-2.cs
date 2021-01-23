	public interface IEvent
	{	
	}
	
	public interface IEventHandler<TEvent> where TEvent: IEvent
	{
		void Handle<TEvent>(TEvent message)
	}
	
	public class EventDispatcher
	{
		private List<object> handlers = new List<object>();
	
		public void Dispatch<TEvent>(TEvent message)
		{
			foreach (var handler in handlers)
			{
				if (handler is IEventHandler<TEvent>)
				{
					var safeHandler = (IEventHandler<TEvent>)handler;
					safeHandler.Handle(message);
				}
			}
		}
	
		public IDisposable Register<TEvent>(IEventHandler<TEvent> handler)
		{
			this.handlers.Add(handler);
			return new Subscription(this, handler);
		}
	
		class Subscription : IDisposable
	    {
	        private EventDispatcher dispatcher;
	        private IEventHandler<TEvent> handler;
	
	        public Subscription(EventDispatcher dispatcher, IEventHandler<TEvent> handler)
	        {
	            this.dispatcher = dispatcher;
	            this.handler = handler;
	        }
	
	        public void Dispose()
	        {
	            if (dispatcher == null)
	                return;
	
	            dispatcher.Unsubscribe(handler);
	            dispatcher = null;
	        }
	    }
	
	    private void Unsubscribe(IEventHandler<TEvent> handler)
	    {
	    	this.handlers.Remove(handler);
	    }
	}
