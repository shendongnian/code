	public class MetricsCommandHandlerWrapper<T> : IHandleCommand<T>, IDecorator where T: ICommand
	{
		private readonly ICollectMetrics _metrics;
		private readonly Func<IHandleCommand<T>> _handlerFactory;
		public MetricsCommandHandlerWrapper(ICollectMetrics metrics,
		  Func<IHandleCommand<T>> handlerFactory) {
		  _metrics = metrics;
		  _handlerFactory = handlerFactory;
		}
		
		public object Decoratee { get { return _handlerFactory(); }
		public async Task HandleAsync(T command) { ... }
	}
