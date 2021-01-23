    public static void Look(LEBAEntities db, object obj) {
        var type = obj.GetType();
        var type = typeof (IdentityUser);
        var objectContext = ((IObjectContextAdapter)context).ObjectContext;
        IEnumerable<string> retval = (IEnumerable<string>)objectContext.MetadataWorkspace
            .GetType(type.Name, type.Namespace, System.Data.Entity.Core.Metadata.Edm.DataSpace.CSpace)
            .MetadataProperties.First(mp => mp.Name == "Id")
            .Value;
    .
    .
    .
