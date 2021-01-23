    public IEnumerable<MyItem> MyItems
    {
        get
        {
            yield return MyHost.GetItemFromID(_i1); //this may be a long operation
            yield return MyHost.GetItemFromID(_i2);
            yield return MyHost.GetItemFromID(_i3);
            yield return MyHost.GetItemFromID(_i4);
            yield return MyHost.GetItemFromID(_i5);
        }
    }
