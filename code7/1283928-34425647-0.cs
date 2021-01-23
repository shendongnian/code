    using(var db = new ARContext())
    {
	  var groupNames = new[] {"CRM_ADMIN","CRM_Boutique1","CRM_Boutique2"};
	
      //Fetch application (AdGroups eager loaded) if it exists, otherwise create a new one
	  var application = db.Applications.Include(a => a.AdGroups)
                                       .FirstOrDefault(a => a.Application == "CRM") 
                                       ?? db.Add(new Application { Application = "CRM" });
      //If the application didn't exist yet, initialize the AdGroup collection
      //Better to do this in the constructor of your application model though
      if(db.Entry(application).State == EntityState.Added)
         application.AdGroups = new List<AdGroup>();
      //Iterate over groupNames that are not part of application.Adgroup's collection			
	  foreach(var name in groupNames.Where(g => !application.AdGroups.Any(ag => ag.GroupName == g)))
	  {
		  AdGroup group = db.AdGroups.FirstOrDefault(ag => ag.GroupName == name) 
                          ?? db.Add(new AdGroup { GroupName = name });
		  application.AdGroups.Add(group);
	  }
      db.SaveChanges();		
    }
