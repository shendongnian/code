    List<string[]> allLineFields = new List<string[]>();
    using (var rd = new StreamReader(@"C:\test.txt"))
    {
        while (!rd.EndOfStream)
        {
            var splits = rd.ReadLine().Split(';');
            allLineFields.Add(splits);
        }
    }
    Console.WriteLine("Date/Time \t Movie \t Seat");
    foreach(string[] line in allLineFields)
        Console.WriteLine(String.Join("\t", line)); 
