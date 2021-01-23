	using System.Linq;
	
	public class Test
	{
		static int getStuff()
		{
			return 1;
		}
		
		public static void Main()
		{
			if ((from option in new int[] {1, 2, 3}
					let thing = getStuff()
					where option == thing
					select option).Any())
				System.Console.WriteLine("in the list!");
		}
	}
