	namespace ConsoleApplication4
	{
		using System;
		using System.Numerics;
		class Program
		{
			static void Main(string[] args)
			{
				Console.WriteLine(Factorial(0));
				Console.WriteLine(Factorial(25));
				Console.WriteLine(Factorial(95));
			}
			private static BigInteger Factorial(int number)
			{
				BigInteger factorial = 1;
				for (var i = number; i > 0; i--)
				{
					factorial *= i;
				}
				return factorial;
			}
		}
	}
----------
    1
    15511210043330985984000000
    10329978488239059262599702099394727095397746340117372869212250571234293987594703124871765375385424468563282236864226607350415360000000000000000000000
    Press any key to continue . . .
