    /// <summary>
    /// Collection item type must have default constructor
    /// </summary>
    /// <param name="items"></param>
    /// <returns></returns>
    public static Object CreateInstanceOfCollectionItem(IEnumerable items)
    {
        try
        {
            var itemType = items.GetType()
                                .GetInterfaces()
                                .FirstOrDefault(t => t.Name == "IEnumerable`1")
                                ?.GetGenericArguments()
                                .First();
            //  If it's not generic, we may be able to retrieve an item and get its type. 
            //  System.Windows.Controls.DataGrid will auto-generate columns for items in 
            //  a non-generic collection, based on the properties of the first object in 
            //  the collection (I tried it).
            if (itemType == null)
            {
                itemType = items.Cast<Object>().FirstOrDefault()?.GetType();
            }
            //  If that failed, we can't do anything. 
            if (itemType == null)
            {
                return null;
            }
            return itemType.Assembly.CreateInstance(itemType.FullName);
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public static TestCreate()
    {
        var e = Enumerable.Empty<Foo.Bar<Foo.Baz>>();
        var result = CreateInstanceOfCollectionItem(e);
    }
