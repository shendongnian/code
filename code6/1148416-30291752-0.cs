    public string RemoveComplaintWhereIDis(string xml, string id)
    {
        XmlDocument x = new XmlDocument();
        xml.LoadXml(xml);
        foreach (XmlNode xn in x.LastChild.ChildNodes)
        {
            if (xn.LastChild.InnerText == id)
            {
                x.LastChild.RemoveChild(xn);
            }
        }
        return x.OuterXml;
    }
