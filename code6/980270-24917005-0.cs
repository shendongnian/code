    private string GetItemName(string _id)
    {
        XmlDocument xDoc = new XmlDocument();
        xDoc.Load("myXmlFile.xml");
        foreach (XmlNode item in xDoc.SelectNodes("/Items/Item"))
        {
            if (item.SelectSingleNode("ID").InnerText == _id)
            {
                // we found the item! Now what do we do?
                return item.SelectSingleNode("Name").InnerText;
            }
        }
        return null;
    }
