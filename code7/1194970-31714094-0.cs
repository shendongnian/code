    static void Main(string[] args)
    {
        List<string> stringList = new List<string>();
        stringList.Add("A");
        stringList.Add("B");
        stringList.Add("C");
        Parallel.ForEach(stringList, aString =>
            {
                Console.WriteLine(aString);
            });
        Console.WriteLine("Hello");
    }
