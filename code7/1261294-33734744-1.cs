	using System;
	namespace Week3_Exe3._1
	{
		public class Formula
		{
			public double calculate(double F)
			{
				return (5.0 / 9.0) * (F - 32.0);
			}
			public static void Main(string[] args)
			{
				Console.WriteLine("Please enter the Fahrenheit you wish to convert");
				var F = double.Parse(Console.ReadLine());
				Formula form = new Formula();
				Console.WriteLine(F + " Fahrenheit correspond to " + form.calculate(F) + " Degrees celcius");
			}
		}
	}
