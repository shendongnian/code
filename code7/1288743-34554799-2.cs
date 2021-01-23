    private static void PrintDivisors(int number, int divideBy)
	{
		if (divideBy == 0)
			Console.WriteLine("Not allowed to divide by 0");
		else if (divideBy == 1)
			Console.WriteLine("All number from 1 to {0} are divisible by 1", number);
		else
		{
			int root = number/2;
			for (var index = 1; index <= root; index++)
			{
				if (number % index == 0)
					Console.WriteLine("{0}, {1}/{2}={3}", index, number, index, number / index);
			}
			if (number % (number / 2) == 0)
				Console.WriteLine("{0}, {1}/{2}={3}", number / 2, number, number / 2, number / (number / 2));
			Console.WriteLine("{0}, {1}/{2}={3}", number, number, number, number / number);
		}
	}
