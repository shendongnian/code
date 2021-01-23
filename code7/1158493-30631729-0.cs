    Type t = GetTypeInsideOfObjectByTypeName(o, tableName, out isCoollection);
    
    Type genericListType = typeof(List<>).MakeGenericType(t);
    
    object coll = Activator.CreateInstance(genericListType);
    
    dynamic objectColl = Convert.ChangeType(coll, coll.GetType());
    
    dynamic d = Convert.ChangeType(obj, obj.GetType());
    
    objectColl.Add(d);
