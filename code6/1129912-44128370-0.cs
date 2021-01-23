	[TestMethod]
	public void CastleWindsor_FactoryThrows_MyException()
	{
		WindsorContainer Container = new WindsorContainer();
		Container.AddFacility<TypedFactoryFacility>();
		Container.Register(Component.For<IMyFactory>().ImplementedBy<MyFactoryDecorator>());
		Container.Register(Component.For<IMyFactory>().AsFactory());
		Container.Register(Component.For<MyClass>().LifestyleTransient());
		var factory = Container.Resolve<IMyFactory>();
		try
		{
			factory.Create();
		}
		catch (Exception e)
		{
			Assert.AreEqual(e.GetType(), typeof(MyException));
		}
	}
	public class MyFactoryDecorator : IMyFactory
	{
		IMyFactory factory;
		public MyFactoryDecorator(IMyFactory aFactory)
		{
			factory = aFactory;
		}
		MyClass IMyFactory.Create() => handleComponentActivatorException(() => factory.Create());
		T handleComponentActivatorException<T>(Func<T> action)
		{
			try
			{
				return action();
			}
			catch (ComponentActivatorException e)
			{
				throw e.InnerException.InnerException;
			}
		}
	}
	public interface IMyFactory
	{
		MyClass Create();
	}
	public class MyException : Exception { }
	public class MyClass
	{
		public MyClass()
		{
			throw new MyException();
		}
	}
