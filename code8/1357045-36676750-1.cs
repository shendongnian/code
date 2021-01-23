    var array = new [,]
    {
        { "a1", "a2" },
        { "b1", "b2" }
    };
    PrintArray(array);
    Console.WriteLine();
    var elements = array
        .EnumerateReferenceElements()
        .ToList();
    foreach (var elem in elements)
    {
        Console.WriteLine(elem);
    }
    elements.ForEach(
        elem =>
            elem.Value = elem.Value + "_n");
                
    Console.WriteLine();
    PrintArray(array);
