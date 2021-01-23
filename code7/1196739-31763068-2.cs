	interface IAddStuff 
	{
		void Add (MyContext context, IList<Foo> list);
		void Add (MyContext context, IList<Bar> list);
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
		public void Add(MyContext context, IList<Foo> list)
		{
			// ...
		}
		public void Add(MyContext context, IList<Bar> list)
		{
			// ...
		}
	}
