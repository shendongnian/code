    HashSet<string> badIds = new HashSet<string>();
    badIds.Add("1");
    badIds.Add("excludeme");
    XDocument xd = XDocument.Load(new StringReader(client.DownloadString(XmlUrl)));
    var badCategories = xd.Root.Descendants("category").Where(x => badIds.Contains((string)x.Attribute("id")));
    if (badCategories != null && badCategories.Any())
      badCategories.Remove();
    MyRoot root = (MyRoot)new XmlSerializer(typeof(MyRoot)).Deserialize(xd.Root.CreateReader());
