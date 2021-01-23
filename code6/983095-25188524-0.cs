    ISessionFactory factory = ... // get your NH ISessionFactory;
            
    // all mapped entities as dictionary
    var allClassMetadata = factory.GetAllClassMetadata();
    foreach (var meta in allClassMetadata)
    {
        var persister = meta.Value as NHibernate.Persister.Entity.AbstractEntityPersister;
        var tableName = persister.TableName;
        var entityName = persister.EntityType.Name;
        ... 
        // TODO what needed with this info
    }
