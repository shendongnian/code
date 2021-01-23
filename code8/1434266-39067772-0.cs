    private void ThisCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        Item I = e.NewItems._________;//<<<<<cannot access any property to get the item
        var j = e.NewItems;//System.Collections.ArrayList.ReadOnlyList, see if you can find in the MSDN docs.
        IList I1 = (IList) e.NewItems;//Cast fails.
        IList<Item> = (IList<Item>)e.NewItems.________;//<<<<<<<Can't make this cast without an IList.Item[Index] accessor.
        var i = j[0]; //null
        var ioption = j.Item[0]; //no such accessor
        string s = (string)i; //null
    }
