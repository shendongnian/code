    public static void foo(List<int> testlist)
    {
        if(testlist == null) 
            throw new ArgumentNullException(nameof(testlist), $"{nameof(testlist)} must not be null");
        if (!testlist.Any())
        {
            Console.WriteLine("testlist is empty!");
        }
    }
