	public class MyClass
	{
		public int GetNumber()
		{
			return 1;
		}
	}
	public class MySubClass : MyClass
	{
		// Note the use of *new*. This isn't a virtual method!
		public new int GetNumber()
		{
			return 2;
		}
	}
	MySubClass[] coll = new[] { new MySubClass(), new MySubClass() };
	var res = coll.Where(x => x.GetNumber() == 2).ToArray(); // 2 elements
	var res2 = coll.Where<MyClass>(x => x.GetNumber() == 2).ToArray(); // 0 elements
	var res3 = coll.Where<MyClass>(x => x.GetNumber() == 1).ToArray(); // 2 elements
