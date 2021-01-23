    Dictionary<string, int> marksDictionary = new Dictionary<string, int>();
    // Just initialize the dictionary instead of the arrays
    marksDictionary.Add("John", 34);
    marksDictionary.Add("Mary", 62);
    marksDictionary.Add("Keith", 71);
    // To get the value, simply read off the dictionary passing in the lookup key
    Console.WriteLine("Marks for John is " + marksDictionary["John"]);
    
