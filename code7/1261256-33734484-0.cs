    Int32 a;
        Int32 b;
        Int32 c;
        decimal d;
        Console.WriteLine("please enter the price of one kilo of tomatoes without VAT.");
        a = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Please enter the amount of kilos you want.");
        b = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("please enter the amount of VAT.");
        c = Convert.ToInt32(Console.ReadLine());
		
		d = ((decimal)a * (1 + (decimal)c / 100)) * b;
		Console.WriteLine(d);
