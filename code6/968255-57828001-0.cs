    public int DeletebyId(string Id)
     {
        var Ent = (IGenricInterface)_sitecontext.Set<TEntity>().Find(Id);
            Ent.IsDeleted = 1;
     }
