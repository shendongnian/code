	static void Main(string[] args)
	{
		int[] values;
		values = new int[10];
		Random rand = new Random();
		for (int i = 0; i < 10; i++)
		{
			values[i] = rand.Next(1,20);
		}
		
		int sum = 0;
		int max = int.MinValue;
		int min = int.MaxValue;
		Array.Sort(values);
		for (int i = 0; i < 10; i++)
		{
			sum += values[i];
			if(values[i] < min)
			{
				min = values[i];
			}
			
			if(values[i] > max)
			{
				max = values[i];
			}
			
			Console.WriteLine(values[i]);
		}
		Console.WriteLine("Min: {0}", min);
		Console.WriteLine("Max: {0}", max);
		Console.WriteLine("Sum: {0}", sum);
		Console.WriteLine("Mean: {0}", sum/values.Length); 
		Console.WriteLine("Median: {0}", (min + max)/2);
	}
	
