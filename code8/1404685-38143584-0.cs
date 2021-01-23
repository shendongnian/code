    public static void foo(List<int> testlist)
    {
        if(testlist == null) 
            throw new ArgumentNullException("testlist must not be null");
        if (!testlist.Any())
        {
            Console.WriteLine("testlist is empty!");
        }
    }
