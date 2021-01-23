    static void AlsoWorks(IEnumerable<A> items)
    {
        foreach(var a in items)
        {
            Console.WriteLine("No problems here!");
        }
    }
    ...
    AlsoWorks(new List<B>());
