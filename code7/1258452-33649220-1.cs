    public List<string> GetDatabases(string serv)
    {
        XDocument xdoc = XDocument.Load("XMLFile1.xml");
        var lstDBName = (from items in xdoc.Descendants("server")
                         where items.Attribute("name").Value == serv
                         from item in items.Elements("database")
                         select item.Value)
                         .ToList();
        return lstDBName;
    }
