    List<string> list1 = new List<string>() {"X", "W", "C", "A", "D", "B" } ;
    List<string> list2 = new List<string>() { "A", "B", "C", "D" } ;
    
    var newList = list2.Intersect(list1)
                       .Union(list1.Except(list2));
