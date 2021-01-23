	public class Bar
	{
		public void DoSomething<T>()
		{
			Console.WriteLine(typeof(T).FullName);
		}
	}
