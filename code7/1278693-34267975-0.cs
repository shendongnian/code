    public class A
	{
	}
	public class B : A
	{
		public static T Create<T>() where T : A, new()
		{
			return new T();
		}
	}
	public class Example
	{
		public void DoWork()
		{
			B b = B.Create<B>();
			A a = B.Create<A>();
		}
	}
