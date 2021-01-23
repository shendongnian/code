    public static XElement GetXElements<T>(IEnumerable<T> collection, string wrapperName)
        where T : class
    {
        return new XElement(wrapperName, collection.Select(GetXElement));
    }
    private static XElement GetXElement<T>(T item)
    {
        return new XElement(typeof(T).Name,
            typeof(T).GetProperties()
                     .Select(prop => new XElement(prop.Name, prop.GetValue(item, null));
    }
