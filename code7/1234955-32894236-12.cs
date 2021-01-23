    public static T CloneXaml<T>(T source)
    {
        UiXamlSerializer uxs = new UiXamlSerializer();
        string xaml = uxs.Serialize(source);
    
        StringReader sr = new StringReader(xaml);
        XmlReader xr = XmlReader.Create(sr);
        return (T)XamlReader.Load(xr);
    }
