	public class Public
	{ }
	internal class Program
	{
		private class Private
		{
			
		}
		[STAThread]
		private static void Main(string[] args)
		{
			Private pr = new Private();
			Console.WriteLine(pr.GetType().IsPublic); // false
			Public pu = new Public();
			Console.WriteLine(pu.GetType().IsPublic); // true
		}
	}
