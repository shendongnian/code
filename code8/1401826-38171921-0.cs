	public class NamespaceRegistrationConvention : RegistrationConvention
	{
		private readonly IEnumerable<Type> _typesToResolve;
		private readonly string _namespacePrefixForInterfaces;
		private readonly string _namespacePrefixForImplementations;
		public NamespaceRegistrationConvention(IEnumerable<Type> typesToResolve, string namespacePrefixForInterfaces, string namespacePrefixForImplementations)
		{
			_typesToResolve = typesToResolve;
			_namespacePrefixForInterfaces = namespacePrefixForInterfaces;
			_namespacePrefixForImplementations = namespacePrefixForImplementations;
		}
		public override IEnumerable<Type> GetTypes()
		{
			// Added the abstract as well. You can filter only interfaces if you wish.
			return _typesToResolve.Where(t =>
				((t.IsInterface || t.IsAbstract) && t.Namespace.StartsWith(_namespacePrefixForInterfaces)) ||
				(!t.IsInterface && !t.IsAbstract && t.Namespace.StartsWith(_namespacePrefixForImplementations)));
		}
		public override Func<Type, IEnumerable<Type>> GetFromTypes()
		{
			return WithMappings.FromMatchingInterface;
		}
		public override Func<Type, string> GetName()
		{
			return WithName.Default;
		}
		public override Func<Type, LifetimeManager> GetLifetimeManager()
		{
			return WithLifetime.Transient;
		}
		public override Func<Type, IEnumerable<InjectionMember>> GetInjectionMembers()
		{
			return null;
		}
	}
