        ObjectContext objectContext = ((System.Data.Entity.Infrastructure.IObjectContextAdapter)context).ObjectContext;
        EntityContainer container = objectContext.MetadataWorkspace.GetEntityContainer(objectContext.DefaultContainerName, DataSpace.CSpace);
        
        //Only works if you keep the default entity associations names pattern
        //ie: ClassName.NavigationProperty
        var t = container.AssociationSets.Where(a => a.Name.Contains(typeof(DerivedType).Name));
        
        foreach (AssociationSet navigationProperty in t)
        {
            String p = navigationProperty.Name;
            var propInfo = typeof(DerivedType).GetProperty(p.Substring(typeof(DerivedType).Name.Length+1));
        }
