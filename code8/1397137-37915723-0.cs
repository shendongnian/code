	public interface IFooFactory {
		IFoo Create(string fooName);
	}
	public class FooFactory : Dictionary<string, Type>, IFooFactory
	{
		private readonly Container container;
		public FooFactory(Container container) { this.container = container; }
		public void Register<T>(string fooName) where T : IFoo {
			this.container.Register(typeof(T));
			this.Add(name, typeof(T));
		}
		public IFoo Create(string fooName) => this.container.GetInstance(this[fooName]);
	}
	// Registration
	var factory = new FooFactory(container);
	container.RegisterSingleton<IFooFactory>(factory);
	factory.Register<SpecificFoo>("foooo");
	factory.Register<AnotherFoo>("another");
