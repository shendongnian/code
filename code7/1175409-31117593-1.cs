        IList<MyObject> list = new List<MyObject>();
        list.Add(new MyObject { Property1 = "A", Property2 = "B", Property3 = "C", Property4 = "D" });
        list.Add(new MyObject { Property1 = "A", Property2 = "A", Property3 = "C", Property4 = "D" });
        list.Add(new MyObject { Property1 = "A", Property2 = "A", Property3 = "A", Property4 = "D" });
        var testObject = new MyObject { Property1 = "A", Property2 = "A", Property3 = "A", Property4 = "A" };
    //list of objects with 3 or matches
        var sorted = list.Select(x => new
        {
            MatchCount = (x.Property1 == testObject.Property1 ? 1 : 0)
                        + (x.Property2 == testObject.Property2 ? 1 : 0)
                        + (x.Property3 == testObject.Property3 ? 1 : 0)
                        + (x.Property4 == testObject.Property4 ? 1 : 0),
            MyObj = x
        })
        .OrderBy( x => x.MatchCount)
        .Where( x => x.MatchCount >= 3 );
    //gets the first object from the list
        var match = sorted.Any() ? sorted.OrderBy(x => x.MatchCount).FirstOrDefault().MyObj : null;
        
