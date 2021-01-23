    List<KeyValuePair<myCustomObject, int>> list =
        new List<KeyValuePair<myCustomObject, int>>();
    //note make sure list is sorted when modified with 
    //list.Sort(MyPairedObjectComparer.Default);
    private void funciton1(int _i)  // Gets called MANY MANY times a second!
    {
        var objectToSearchWith = new myCustomObject()
        {
            b = _i + 1,
        };
        var pair = new KeyValuePair<myCustomObject, int>(objectToSearchWith, 0);
        var index = list.BinarySearch(pair, MyPairedObjectComparer.Default);
        if (index < 0)
            index = ~index;
        for (int i = index; i < list.Count; i++)
        {
            doSomething(list[i].Value);
        }
    }
