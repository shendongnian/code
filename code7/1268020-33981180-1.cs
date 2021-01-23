    var dcx = new MyDbContext();
    var objContext = ((IObjectContextAdapter)dcx).ObjectContext;
    var types = db.ObjectContext.MetadataWorkspace.GetItems<EntityType>(DataSpace.OSpace).Select(x => Type.GetType(x.FullName));
    foreach (var t in lst) {
    ...
