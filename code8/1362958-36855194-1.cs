    private static XDocument xliff;
    public static int[] GetTagArray(string FilePath)
    {
        xliff = XDocument.Load(Path.GetFullPath(FilePath));
        XNamespace ns = "http://sdl.com/FileTypes/SdlXliff/1.0";
        int[] elements = xliff.Descendants().Elements(ns + "tag-defs").Elements(ns + "tag").Elements(ns + "ph").Select(e => Int32.Parse(e.Parent.Attribute("id").Value)).ToArray();
        int[] elements2 = xliff.Descendants().Elements(ns + "tag-defs").Elements(ns + "tag").Elements(ns + "bpt").Select(e => Int32.Parse(e.Parent.Attribute("id").Value)).ToArray();
        int[] intarray = elements.Concat(elements2).ToArray();
        Array.Sort(intarray);
        return intarray;
    }
