    public IQueryable getTheEntity(DbContext database) {
        var query = from e in database.MainEntity.Include("SubEntity1.Another").Include("SubEntity2");
    
        return query;
    }
