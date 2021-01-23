	class MyContext {}
	class Foo {}
	class Bar {}
	interface IAddStuff 
	{
		void Add<T> (MyContext context, IList<T> list);
	}
	class Operations
	{
		public static void MySetUp(MyContext context, IAddStuff adder)
		{
			var list1 = new List<Foo> ();
			adder.Add (context, list1);
			var list2 = new List<Bar> ();
			adder.Add (context, list2);
		}
	}
	class SampleImplementation : IAddStuff 
	{
		public void Add<T> (MyContext context, IList<T> list)
		{
			if (typeof(T) == typeof(Foo)) 
				AddFoo(context, list.Cast<Foo>());
			else if (typeof(T) == typeof(Bar)) 
				AddBar(context, list.Cast<Bar>());
		}
		void AddFoo(MyContext context, IEnumerable<Foo> list)
		{
			// ...
		}
		void AddBar(MyContext context, IEnumerable<Bar> list)
		{
			// ...
		}
	}
