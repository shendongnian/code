    public static class A
	{
		public static void DoWork(this Enum en)
		{
			Console.WriteLine(en);
		}
        public static void DoWork(this int en)
		{
			Console.WriteLine(en);
		}
	}
	public enum Pets
	{
		Cat,
		Dog
	}
	internal class Program
	{
		private static void Main(string[] args)
		{
			var cat = Pets.Cat;
            //Enum.DoWork(); doesn't work
			cat.DoWork(); // works fine
            //int.DoWork(); doesn't work
			5.DoWork(); // works fine
			Console.ReadKey();
		}
	}
