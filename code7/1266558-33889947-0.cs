    var original = new List<int> { 1, 2, 3 };
    IReadOnlyList<int> readOnlyList = original;
    Console.WriteLine(readOnlyList[0]); // Compiles.
    readOnlyList[0] = 0; // Does not compile.
    var readOnlyCollection = original.AsReadOnly();
    readOnlyCollection[0] = 1; // Does not compile.
    IList<int> collection = readOnlyCollection; // Compiles.
    collection[0] = 1; // Compiles, but throws runtime exception. 
