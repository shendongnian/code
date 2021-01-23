    List<int?> valueArray = new List<int?>();
    List<int?> secondValueArray = new List<int?>();
    //... fill lists
    valueArray.Add( 1 );
    valueArray.Add(2);
    valueArray.Add(3);
    secondValueArray.Add( 4 );
    while (valueArray.Count > secondValueArray.Count)
        secondValueArray.Add(null);
    while (secondValueArray.Count > valueArray.Count)
        valueArray.Add(null);
    for (int i = 0; i < valueArray.Count(); i++)
    {
        var newLine = string.Format("{0},{1}", valueArray.ElementAt(i), secondValueArray.ElementAt(i));
        Console.WriteLine(newLine);
    }
    ;
