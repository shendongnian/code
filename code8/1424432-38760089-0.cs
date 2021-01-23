    List<int> foo = new List<int> { 1, 2, 3 };
    List<int> bar = new List<int> { 3, 4, 5 };
    //This will give you all items from both collections
    var array = Enumerable.Concat(foo, bar).ToArray(); // 1,2,3,3,4,5
    var array = foo.Concat(bar).ToArray();
    //This will give you all distinct items
    var array = Enumerable.Union(foo, bar).ToArray(); //1,2,3,4,5
    var array = foo.Union(bar).ToArray();
