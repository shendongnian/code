	public class LifetimeScopeDecorator<TRequest, TResponse> :
		IRequestHandler<TRequest, TResponse>
		where TRequest : IRequest<TResponse>
	{
		private readonly Func<IRequestHandler<TRequest, TResponse>> _decorateeFactory;
		private readonly Container _container;
		public LifetimeScopeDecorator(
			Func<IRequestHandler<TRequest, TResponse>> decorateeFactory,
			Container container)
		{
			_decorateeFactory = decorateeFactory;
			_container = container;
		}
		public TResponse Handle(TRequest message)
		{
			using (_container.BeginLifetimeScope())
			{
				var result = _decorateeFactory.Invoke().Handle(message);
				return result;
			}
		}
	}
