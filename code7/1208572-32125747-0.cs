    List<List<int>> list = new List<List<int>>();
    IList<IList<int>> ilist = list;  // imagine a world where this was legal
    
    // This is already allowed by the type system
    ilist.Add(new int[] { 1, 2, 3 });
    
    // This is actually an array! Not a List<>
    List<int> first = list[0];
