	public class CustomAssemblyResolver : IAssembliesResolver
	{
		private readonly Assembly[] _assemblies;
		public CustomAssemblyResolver(params Assembly[] assemblies)
		{
			_assemblies = assemblies;
		}
		public ICollection<Assembly> GetAssemblies()
		{
			return _assemblies;
		}
	}
