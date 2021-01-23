    List<string> data = new List<string>
    {
        "john   teacher 1988 married",
        "marcel engineer1976 single",
        "emi    professo1975 married"
    };
    Console.WriteLine("Before: ");
    data.ForEach(Console.WriteLine);
    Console.WriteLine();
    int runningNumber = 1;
    for (int i = 0; i < data.Count; i++)
    {
        data[i] = data[i].Insert(20, String.Format("D{0:000}", runningNumber));
        runningNumber++;
    }
    Console.WriteLine("After: ");
    data.ForEach(Console.WriteLine);
