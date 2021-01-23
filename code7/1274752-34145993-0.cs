    [HttpPost]
    public ActionResult Edit(FormCollection collection)
    {
      
        var config = WebConfigurationManager.OpenWebConfiguration("~");
         
        var db = config.AppSettings.Settings["DatabaseServerName"];
        if (db != null)
        {
           config.AppSettings.Settings["DatabaseServerName"].Value = id;
        }
        else
        {
           var dbEntry=new KeyValueConfigurationElement("DatabaseServerName",id);
           config.AppSettings.Settings.Add(dbEntry);
        }
        config.Save();
        // to do  : Redirect to a success action (PRG pattern)
    }
