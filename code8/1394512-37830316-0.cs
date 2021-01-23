    public interface INetworkWorkerFactory
	{
		NetworkWorker Create();
	}
    public class NetworkWorkerFactory : INetworkWorkerFactory
	{
		private readonly IContainer _container;
		public NetworkWorkerFactory(IContainer container)
		{
			_container = container;
		}
		public NewtorkWorker Create(int numberOfResources)
		{
			var retryService = _container.GetInstance<IRetryService>();
			var log = _container.GetInstance<ILog>();
			return new NewtorkWorker(retryService, log, numberOfResources);
		}
	}
