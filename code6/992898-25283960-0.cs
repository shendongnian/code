    var query = from p in db.Project
        select new A {
            Project = p,
            Capacity = (from pp in db.ProjectActualCapacity                                                              
                        where pp.ProjectID == p.ID
                        select new Capacity {
                            Actual = pp.Hours,                                                                 
                            Date = pp.Date,
                            ProjectID = pp.ProjectID
                        }
                       ).ToList())
       };
