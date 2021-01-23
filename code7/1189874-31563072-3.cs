    public static string Fetch2Xml(string s)
    {      
        return HttpUtility.HtmlDecode(s);
    }
    private static void Main(string[] args)
    {
        String s = "&lt;fetch distinct=\"false\" no-lock=\"false\" mapping=\"logical\" /&gt;";
        String[] sa = new string[] { s, s, s, s, s, s, s };
        XmlDocument doc = new XmlDocument();
        XmlElement someRoot = doc.CreateElement("mappings");
        XmlElement ele = doc.CreateElement("main_fetchxml");
        ele.InnerXml = Fetch2Xml(sa[0]);
        someRoot.AppendChild(ele);
        XmlElement ele2 = doc.CreateElement("relatedqueries");
        for (int a = 1; a < sa.Length; ++a)
        {
            ele2.InnerXml += Fetch2Xml(sa[a]);
        }
        someRoot.AppendChild(ele2);
        doc.AppendChild(someRoot);
        doc.Save(@"c:\temp\bla.xml");
    }
