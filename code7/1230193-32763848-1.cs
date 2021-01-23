    var dict = new DoubleKeyDictionary();
    dict.Add(123, 1);
    dict.Add(234, 2);
    dict.Add("k1", 3);
    dict.Add("k2", 4);            
    dict[456] = 5;
    dict["k3"] = 6;
    dict.Add(new KeyValueSet("k4", 567, 7));
    dict.Remove(123);
    Console.WriteLine(dict[234]); //2
    Console.WriteLine(dict["k2"]); //4
    Console.WriteLine(dict[456]); //5
    Console.WriteLine(dict[567]); //7
    Console.WriteLine(dict["k4"]); //7
    Console.WriteLine(dict[123]); //exception
