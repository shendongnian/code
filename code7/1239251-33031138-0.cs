    using System;
    using System.Linq;
    using System.Collections.Generic;
					
	public class Program
	{
		public static void Main()
		{
			var array = new int[]{ 4,1,5,4,3,1,6,5 };
			var arrayWithoutDuplicate = new HashSet<int>(array).ToArray();
		
			foreach (var item in arrayWithoutDuplicate)
				Console.WriteLine(item);
		}
	}
