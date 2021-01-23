    static XElement DictionaryToXml(object o, FieldInfo f)
    {
        string nam = f.Name;
        XElement container = new XElement(nam, new XAttribute("type", "dictionary"));
        IDictionary dict = (IDictionary)f.GetValue(o);
        foreach (DictionaryEntry obj in dict)
        {
            //some code using obj.Key and obj.Value
        }
        return container;
    }
