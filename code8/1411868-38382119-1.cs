    using (db = new DbContext())
    {
      var site_a = db.SitesA.Find(123); // 1 should be the key of site a
      var site_b = db.SitesB.Find(456); // 2 should be the key of site b
      Sample sample = new Sample()
      {
         SiteA = site_a,
         SiteB = site_b
      };
      db.Samples.Add(sample);
      db.SaveChanges();
    }
