    int op = 0;
    string in = string.Empty;
	do
	{
		Console.WriteLine("enter choice");
		in = Console.ReadLine();
	} while (!int.TryParse(in, out op));
