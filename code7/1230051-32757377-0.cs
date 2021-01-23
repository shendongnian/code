    CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(c.Items);
    view.Filter = i =>
    {
        var index1 = c.MyData.FindIndex(delegate (MyClass s)
        {
            return Object.ReferenceEquals(s, i);
        });
        var index2 = c.MyData.FindLastIndex(delegate (MyClass s)
        {
            return ((MyClass)i).MyProperty == s.MyProperty as string; //value comparison
        });
        return index1 == index2;
    };
