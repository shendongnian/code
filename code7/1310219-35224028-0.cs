	Dictionary<string, int>  myDictionary = new Dictionary<string, int>()
    {
        {"Insertion Sort", 12},
        {"Selection Sort ", 35},
        {"Bubble Sort", 42},
        {"Merge Sort", 52},
        {"Quick Sort ", 32}
    };
    var min = myDictionary.First(kv => kv.Value == myDictionary.Values.Min());
    Console.Out.WriteLine("The fastest is " + min.Key + " with a time of " + min.Value + "ms");
