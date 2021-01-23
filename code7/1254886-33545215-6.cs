    public ActionResult Create(ConfigurationCollection con)
    {
        db.ConfigurationCollection.Add(con);
        //all of the OptionValues inside the 'con' object will be automatically inserted
        db.SaveChanges();
    }
