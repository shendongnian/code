    IEnumerable<IDictionary<string,object>> GetKeyValues<T>(DbContext db, 
                                                            IEnumerable<T> entities)
        where T : class
    {
        var oc = ((IObjectContextAdapter)db).ObjectContext;
        return entities.Select (e => oc.ObjectStateManager.GetObjectStateEntry(e))
                       .Select(objectStateEntry => objectStateEntry.EntityKey)
                       .Select(ek => ek.EntityKeyValues
                                       .ToDictionary (x => x.Key, y => y.Value));
    }
