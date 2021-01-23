    var temp = new MyClass[]
    {
        new MyClass { Name = "object1", Array = new int[] { 1, 2, 3 } },
        new MyClass { Name = "object2", Array = new int[] { 1, 2 } },
        new MyClass { Name = "object3", Array = new int[] { 1, 2 } },
        new MyClass { Name = "object4", Array =null }
    };
    var result = temp.GroupBy(i => i.Array, new ArrayComparer()).ToList();
    //Now you have 3 groups
