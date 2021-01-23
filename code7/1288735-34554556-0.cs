	Console.WriteLine("enter 3 num");
	int num1 = Convert.ToInt32(Console.ReadLine());
	int num2 = Convert.ToInt32(Console.ReadLine());
	int num3 = Convert.ToInt32(Console.ReadLine());
	
	int n = num1;
	while (n <= num2)
	{
		if (n % num3 == 0)
		{
			Console.WriteLine(n);
		}
		n++;
	}
