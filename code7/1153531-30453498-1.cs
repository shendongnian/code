    public EntityClassLite GetLiteById(int id)
    {
        return db.Set<EntityClass>()
                 .All
                 .Where(e => e.Id = id)
                 .Select( new EntityClassLite
                        {
                           Column2 = e.Column2
                           Column3 = e.Column3
                           Column7 = e.Column7
                        }
                 .FirstOrDefault()
    }
