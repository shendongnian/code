	public class Test1<T> where T : TestMain
	{
		public T SomeProperty { get; private set; }
		public Test1(T test)
		{
			SomeProperty = test;
		}   
	}   
	public class Test2
	{
		public TestMain SomeProperty { get; private set; }
		public Test2(TestMain test)
		{
			SomeProperty = test;
		}
	}
