	abstract class AbstractObject {}
	class Test :  AbstractObject
	{
		public Test()
		{
			Console.WriteLine("I work");
		}
	}
	class GenTest<T> where T: AbstractObject, new()
	{
		T obj;
		public GenTest()
		{
			obj = new T();
		}
	}
	
	public static void Main()
	{
		var genTestObj = new GenTest<Test>();
	}
