	internal class Program
	{
        public class Public
	    { }
		
        [STAThread]
		private static void Main(string[] args)
		{
			Public pu = new Public();
			Console.WriteLine(pu.GetType().IsPublic); // false, because Program is internal
		}
	}
