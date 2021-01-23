	class Program
	{
		static void Main(string[] args)
		{
			double[] prices = new double[5];
			int count = 0;
			double TotalValues = 0;
			double Average = 0;
			string inputString;
			double lessthanfive = 0;
			double higherthanaverage = 0;
			int x;
			for (x = 0; x < prices.Length; x++)
			{
				count += 1;
				Console.Write("Enter the price for {0}: ", count);
				inputString = Console.ReadLine();
				prices[x] = Convert.ToDouble(inputString);
				TotalValues += prices[x];
				if (prices[x] < 5)
					lessthanfive++;
			}
			Average = prices.Average();
			higherthanaverage = prices.Where(price => price > Average).Count();
			Console.WriteLine();
			Console.WriteLine("The Sum of The Values Are: {0:C2}", TotalValues);
			Console.WriteLine("Numbers Less Than $5.00 Are: {0:C2}", lessthanfive);
			Console.WriteLine("The Average of The 20 Prices Are: {0:C2}", Average);
			Console.WriteLine("Numbers Higher then Average Are: {0:C2}", higherthanaverage);
			Console.ReadLine();
		}
	}
