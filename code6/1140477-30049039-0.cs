    public ActionResult Create(Project project)
    {
       SampleDb db=new SampleDb();
       // Add audit info
       project.DateTimeCreated = DateTime.Now; 
       project.DateTimeUpdated = DateTime.Now; 
       
       //Save entity
       db.Projects.Add(project);
       db.SaveChanges();
    }
