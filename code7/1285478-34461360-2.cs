    public static MyXExtensions 
    {
        public static string[] ChildrenNames(this XElement xElem)
        {
            return xElem.Elements().Select(e => e.Name.LocalName).ToArray();
        }
    }
    string[] names1 = xDoc.Root.ChildrenNames();
    string[] names2 = xDoc.Root.Element("AChau").ChildrenNames();
    string[] names3 = xDoc.XPathSelectElement("Location/AChau/ACity").ChildrenNames();
