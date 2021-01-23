    public class Program
    {
        public static void Main()
        {
            //Dependency register logic here. Choose either
			
            //var service = new DataServiceAdapter<SpecificNotDisposableDataService>();
			var service = new DataServiceAdapter<SpecificDisposableDataService>();
			
            var client = new Client(service);
            client.ClientMethod();
			Console.ReadLine();
		}
    }
    public class Client
    {
        private readonly IDataServiceAdapter<IDataService> _service;
        public Client(IDataServiceAdapter<IDataService> service)
        {
            _service = service;
        }
        public void ClientMethod()
        {
            Console.WriteLine(_service.Run(s => s.Foo()));
            Console.WriteLine(_service.Run(s => s.Bar("Hello")));
        }
    }
    public class DataServiceAdapter<TService> : IDataServiceAdapter<TService>
        where TService : IDataService, new()
    {
		private interface IRunner
		{
			T Run<T>(Func<TService, T> func);
		}
		private class WithUsing : IRunner
		{
			public T Run<T>(Func<TService, T> func)
			{
				using (var service = (IDisposable) new TService())
				{
					return func((TService)service);
				}
			}
		}
		private class WithoutUsing : IRunner
		{
	        private readonly TService _service = new TService();
			public T Run<T>(Func<TService, T> func)
			{
				return func(_service);
			}
		}
        private readonly IRunner _runner;
			
        public DataServiceAdapter()
        {
            if (typeof(IDisposable).IsAssignableFrom(typeof(TService)))
            {
                _runner = new WithUsing();
            }
            else
            {
                _runner = new WithoutUsing();
            }
        }
		public T Run<T>(Func<TService, T> func)
        {
            return _runner.Run<T>(func);
        }
    }
    public class SpecificDisposableDataService : IDataService, IDisposable
    {
        public bool Foo()
        {
            return true;
        }
        public int Bar(string arg)
        {
            return arg.Length;
        }
        public void Dispose()
        {
            //Dispose logic here
        }
    }
	public class SpecificNotDisposableDataService : IDataService
    {
        public bool Foo()
        {
            return false;
        }
        public int Bar(string arg)
        {
            return arg.Length*2;
        }
    }
    public interface IDataServiceAdapter<out TService>
        where TService : IDataService
    {
        T Run<T>(Func<TService, T> func);
    }
    public interface IDataService
    {
        bool Foo();
        int Bar(string arg);
    }
