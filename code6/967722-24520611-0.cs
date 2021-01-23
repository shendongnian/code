    static void Main(string[] args)
    {
        List<MyObject> objects = new List<MyObject> {
            new MyObject { name = "name1", locationInfo = "location1", otherObjectName = "otherobjectname1" },
            new MyObject { name = "name2", locationInfo = "location2", otherObjectName = "otherobjectname1" },
            new MyObject { name = "name3", locationInfo = "location3", otherObjectName = "otherobjectname1" },
            new MyObject { name = "name4", locationInfo = "location6", otherObjectName = "otherobjectname2" },
            new MyObject { name = "name5", locationInfo = "location7", otherObjectName = "otherobjectname2" },
        };
    
        var query = objects.GroupBy(o => o.otherObjectName)
            .Select(g => g.First());
    
        foreach(var o in query)
            Console.WriteLine("{0} {1}", o.name,  o.otherObjectName);
    }
