	using System;
	using System.Collections.Generic;
	using System.Linq;
						
	public class Program
	{
		public static void Main()
		{
				var r = new List<char[]> { new char[]{ 'a', 'b', 'c', 'd' }, 
					new char[]{ 'a', 'b', 'c', 'd', 'O' } };
				Console.WriteLine((from r1 in r
				where (r1!=null && r1.Length>=5) && r1[4] == 'O'
				select r1).Count());
		}
		
	}
