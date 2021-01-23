	Console.WriteLine("Introduce amount of wraps");
	int Wrap = Int32.Parse(Console.ReadLine());
	Console.WriteLine("Introduce number of freebies per wrap");
	int Freebie = Int32.Parse(Console.ReadLine());
	Console.WriteLine("Introduce amount of candy bought");
	int Buy = Int32.Parse(Console.ReadLine());
	if (Freebie > Buy || Freebie >= Wrap)
	{
		Console.WriteLine("COMPANY GOES BANKRUPT");
	}
	else
	{
		int TotalFreebie = (Buy / Wrap) * Freebie;
		int Eaten = Buy + TotalFreebie + (TotalFreebie / Wrap);
		int WrapsLeft = Eaten - Buy - (TotalFreebie > Wrap ? TotalFreebie : 0);
		Console.WriteLine("{0} {1}", Eaten, WrapsLeft);
	}
	Console.ReadLine();
