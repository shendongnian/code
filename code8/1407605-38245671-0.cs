    var xmldoc = new XmlDocument();
    xmldoc.Load("url");
    var xnlist = XElement.Parse(xmldoc.InnerXml);
    foreach (var xn in xnlist.Elements())
    {
        PrayerTimes pt = new PrayerTimes();
        pt.day = xn.Attribute("day").Value;
        prayertimes.Add(pt);
    }
