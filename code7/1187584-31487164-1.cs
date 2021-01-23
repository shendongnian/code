    var mylist = new List<string> {"%1", "%136%250%3", "%1%5%20%1%10%50%8%3", "%4%255%20%1%14%50%8%4"};
    var mappedValues = new SortedDictionary<int, IList<string>>();
    mylist.ForEach(str =>
    {
        var count = str.Count(c => c == '%');
        if (mappedValues.ContainsKey(count))
        {
            mappedValues[count].Add(str);
        }
        else
        {
            mappedValues[count] = new List<string> { str };
        }
    });
    // output to validate output
    foreach (var str in mappedValues.Last().Value)
    {
        Console.WriteLine(str);
    }
