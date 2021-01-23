    @using (MyApp.Models.ProjectsEntities db = new VodenjeDel.Models.ProjektiEntities()) {
        db.Configuration.LazyLoadingEnabled = false;
        var projects = db.projects; // no related data available
        
        db.Configuration.LazyLoadingEnabled = true;
        var projects = db.projects; // related data available
    }
