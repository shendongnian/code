	using System;
	public class Program
	{
		public static void Main()
		{
			var str1 = "10101";
			var str2 = "11100";
			var mask = str1.Replace('0','1');
			int one = Convert.ToInt32(str1, 2);
			int two = Convert.ToInt32(str2, 2);
			int maskbit = Convert.ToInt32(mask, 2);
			int result = (one | two)^maskbit;
			
			if (result==0){
				
				Console.WriteLine("All flags set"); 			
			}
			else			
			{
				Console.WriteLine("Not all flags set"); 			
			}	
		}
	}
