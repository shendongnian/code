    Dictionary<char, Tuple<string, int>> myDictionaryTuple = new Dictionary<char, Tuple<string, int>> { {'M', new Tuple<string, int>("Male", 0)}, {'F', new Tuple<string, int>("Female", 1) }, {'U', new Tuple<string, int>("Unknown", 2)}};
		
    Console.WriteLine(myDictionaryTuple['U'].Item1); // Results in "Unknown"
    Console.WriteLine(myDictionaryTuple['U'].Item2); // Results in 1
    Console.WriteLine(myDictionaryTuple['U']); // Results in "(Unknown, 1)"
