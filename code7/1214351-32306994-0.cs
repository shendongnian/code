	public class MessageSubscriptor:IMessageSubscriptorPool
	{
		private readonly Dictionary<Type, Delegate> _callbacks = new Dictionary<Type, Delegate>();
		
		public void Subscribe<T>(Action<T> callback) where T :IMessage
		{
			_callbacks.Add(typeof(T), callback);
		}
	}
	
