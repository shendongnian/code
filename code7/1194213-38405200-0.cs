	public class Program
	{	
		public static void Main()
		{
			Tools.Delegater.Work();
		}
	}
	
	namespace Tools 
	{
		public static class Delegater
		{	
			public static System.Action Work = () => 
			{
				var query = from x in Weapons
							select x;
			};
		}
	}
	
	namespace Tools.Weapons
	{
		public class Cannon { }
	}
