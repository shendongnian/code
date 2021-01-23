	private sealed class SimpleInjectorMessageDispatcher : IMessageDispatcher
	{
		private readonly Container container;
		public SimpleInjectorMessageDispatcher(Container container) {
			this.container = container;
		}
		
		public void Dispatch(object message) {
			Type handlerType = typeof(IMessageHandler<>).MakeGenericType(message.GetType());
			dynamic handler = this.container.GetInstance(handlerType);
			handler.Handle((dynamic)message);
		}
	}
