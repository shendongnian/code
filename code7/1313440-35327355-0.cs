     var info=testing.Root.Element("Response").Descendants("Warranty");
        foreach (var qry in info)
        {
            if(qry.Slect(x => (string)x.Element("ServiceLevelDescription")).Count()>1)
            {
                 qry.Remove();
            }
        }
