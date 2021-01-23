    class Base { }
	class Derived : Base { }
	interface IWrapper<out T>
	{
		T Value { get; }
	}
	class Wrapper<T> : IWrapper<T>
	{
		public T Value { get; private set; }
		public Wrapper(T value) { Value = value; }
	}
	class Program
	{
		static void Main(string[] args)
		{
			IWrapper<Base> wrapper = new Wrapper<Derived>(new Derived());
		}
	}
