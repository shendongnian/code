	List<Func<MyItem>> map = new List<Func<MyItem>> 
	{ 
		() => MyHost.GetItemFromID(_i1),
        () => MyHost.GetItemFromID(_i2), 
        () => MyHost.GetItemFromID(_i3), 
        () => MyHost.GetItemFromID(_i4), 
        () => MyHost.GetItemFromID(_i5), 		 
	};
    public IEnumerable<MyItem> myList(params int[] indices)
    {
		foreach (var index in indices)
			yield return map[index]();
    }
    //so you call 
    myList(0); // or
    myList(4); // or
    myList(1, 3); // all loaded only on demand
