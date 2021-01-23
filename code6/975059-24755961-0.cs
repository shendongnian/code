    public IQueryable<Test.Project> ListView1_GetData()
    {
        using (DREntities2 db=new DREntities2())
        {
            return db.GetLatestProjects().Select(p => new Test.Project
            {
                ProjectId = p.ProjectId,
                Title = p.Title,
                ShortDescr = p.ShortDescr,
                Full_Descr = p.Full_Descr,
                ProCatID = p.ProCatID,
                Marquee = p.Marquee
            }).AsQueryable();
        }
    }
