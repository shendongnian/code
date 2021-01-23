	dynamic list = new [] {new{Price = "1"},new{Price = "2"}};
    // This produces the error you're describing:
	Console.WriteLine(list.Sum(x => Int32.Parse(x.Price)));
    // This works.
	Console.WriteLine(new List<dynamic>(list).Sum(x => Int32.Parse(x.Price)));
