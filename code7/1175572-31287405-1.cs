	public abstract class ModuleProviderBase
	{
		private readonly List<IModule> _modules = new List<IModule>();
		protected ModuleProviderBase()
		{
			Setup();
		}
		public IEnumerable<IModule> GetModules()
		{
			return _modules.OrderBy(m => m.Order);
		}
		protected void AddModule<T>() where T : IModule, new()
		{
			var module = new T();
			_modules.Add(module);
		}
		protected virtual void Setup() { }
	}
