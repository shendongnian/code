    public Project[] Find(Expression<Func<Project, bool> filter = null)
    {    
        using (var db = new ProjetDbConext())
        {
            var query = db.ProjectSet.Where(p => p.CreateDateTime != null);
    
            if(filter != null)
                query = query.Where(filter);
            
           return query.ToArray();
        }
    }
