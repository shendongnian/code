    public ActionResult Bar()
    {
        List<WOWClass> list = new List<WOWClass>();
        string url = "http://eu.battle.net/wow/en/feed/news";
        using (XmlReader reader = XmlReader.Create(url))
        {
            SyndicationFeed feed = SyndicationFeed.Load(reader);
    
            foreach (SyndicationItem item in feed.Items)
            {
                //populate your list
            }
        }
        reader.Close();
        ViewBag.tytul = temat;
        ViewBag.opis = podpis;
        ViewBag.c = czas;
        return PartialView("_Bar", list);
    }
