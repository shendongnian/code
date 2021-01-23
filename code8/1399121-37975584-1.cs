    public static Object CreateInstanceOfCollectionItem(object items)
    {
        try
        {
            var itemType = items.GetType()
                                .GetInterfaces()
                                .FirstOrDefault(t => t.Name == "IEnumerable`1")
                                ?.GetGenericArguments()
                                .First();
            if (itemType == null)
            {
                throw new ArgumentException("items does not implement IEnumerable<T>");
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
