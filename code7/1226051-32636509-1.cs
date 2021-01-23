    static void AlsoWorks(IEnumerable<A> items)
    {
        foreach(var a in aListType)
        {
            Console.WriteLine("No problems here!");
        }
    }
    ...
    AlsoWorks(new List<B>());
