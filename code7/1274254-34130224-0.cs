	using System;
						
	public class Program
	{
		public static void Main()
		{
			string s1 = "Hello";
			string s2 = string2();
			Console.WriteLine ( object.ReferenceEquals(s1, s2 )); // true
			
			string s3 = "Hel";
			s3 = s3 + "lo";
			
			Console.WriteLine ( object.ReferenceEquals(s1, s3 )); // false
			Console.WriteLine (s1, s3); // true
			
			s3 = string.Intern(s3);
			Console.WriteLine ( object.ReferenceEquals(s1, s3 )); // now true
			
			Console.ReadLine();
		}
		
		private static string string2()
		{
			return "Hello";
		}
	}
