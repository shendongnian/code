    public SchemeVersion GetSchemeVersion(int id)
    {
            using(var db = new MyDbContext())
            {
                var entity = db.SchemesVersions.SingleOrDefault(x => x.Id == id);
                entity.SetCalculatedValues();
                return entity;
            }         
    }
