    static void Main(string[] args)
    {
        List<Foo> myList = new List<Foo>();
        myList.Add(new Foo(1, 2, 1, 10));
        myList.Add(new Foo(1, 2, 1, 20));
        myList.Add(new Foo(1, 3, 2, 30));
        myList.Add(new Foo(2, 3, 4, 40));
        myList.Add(new Foo(1, 3, 2, 50));
    
        // The following returns 3 results with 20, 50 and 40 timeStamps.
        var results = myList.GroupBy(x => new { x.SomeId, x.AnotherId, x.SomeOtherId })
                                .Select(g => g.OrderByDescending(o => o.Timestamp).First()).ToList();
    }
