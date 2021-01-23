	public interface IMonitor
	{
		void Start();
		void Stop();
	}
	public class MonitorManager
	{
		internal class Item
		{
			public readonly string Description;
			public readonly Dictionary<string, string> Settings;
			public IMonitorFactory Factory { get; set; }
			public IMonitor Instance { get; set; }
			public Item(string description, Dictionary<string, string> settings, IMonitorFactory factory)
			{
				Description = description;
				Settings = settings;
				Factory = factory;
			}
		}
		private readonly Container _container;
		readonly Dictionary<Guid, Item> _list = new Dictionary<Guid, Item>();
		public MonitorManager(Container container)
		{
			_container = container;
		}
        // some external code would call this for each plugin that is found and
        // either loaded dynamically at runtime or a static list at compile time
		public void Add(Guid id, string description, Dictionary<string, string> settings, IMonitorFactory factory)
		{
			_list.Add(id, new Item(description, settings, factory));
			factory.RegisterContainerAndTypes(_container);
		}
		public void CreateAndRun()
		{
			foreach (var item in _list)
			{                
				var id = item.Key; // this is the guid we want to inject on construction
				var value = item.Value;
				var settings = value.Settings; // use this settings dictionary value on injection
				
				var factory = value.Factory;
				// for each below call, somehow use the values id, and settings
				value.Instance = factory.Create(id, settings);
				value.Instance.Start();
			}
		}
		public void Stop()
		{
			foreach (var value in _list.Select(item => item.Value))
			{
				value.Instance?.Stop();
			}
		}
	}
