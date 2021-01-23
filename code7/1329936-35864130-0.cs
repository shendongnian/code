    XmlDocument doc = new XmlDocument();
    doc.Load("file.xml");
    List<Rate> rates = new List<Rate>();
    XmlNodeList nodes = doc.SelectNodes("//rate");
    foreach(XmlNode x in nodes)
    {
        Rate r = new Rate();
        r.Category = x.Attributes["category"].Value;
        r.Date = DateTime.ParseExact(x.Attributes["date"].Value,"yyyy-MM-dd", null)x.Attributes["category"].Value;
        r.Value = double.Parse(x.SelectSingleNode("./value").InnerText));
        rates.Add(r);
    }
