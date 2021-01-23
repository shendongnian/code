    private static XDocument xliff;
    public static List<XAttribute> GetTagArray(string FilePath)
    {
        xliff = XDocument.Load(Path.GetFullPath(FilePath));
        XNamespace ns = "http://sdl.com/FileTypes/SdlXliff/1.0";
        var elements = xliff.Descendants().Elements(ns + "tag-defs").Elements(ns + "tag")
            .Elements(ns + "ph").Select(e => e.Parent.Attribute("id")).ToList();
        return elements == null ? null : elements;
    }
