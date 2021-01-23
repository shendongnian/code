    var dict = new OrderedDictionary();
    dict.Add("My String Key", "My String");
    dict.Add(12345, 54321);
    Console.WriteLine(dict[0]); // Prints "My String"
    Console.WriteLine(dict[1]); // Prints 54321
    Console.WriteLine(dict["My String Key"]); // Prints "My String"
    Console.WriteLine(dict[(object)12345]);   // Prints 54321 (note the need to cast!)
