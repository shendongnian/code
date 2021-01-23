        FrameLogTypeToSystemType(myDbContext, myObjectChange);
        public Type FrameLogTypeToSystemType<TPrincipal>(DbContext db, IObjectChange<TPrincipal> objectChange)
        {
            var objectContext = ((IObjectContextAdapter)db).ObjectContext;
            var container = objectContext.MetadataWorkspace.GetEntityContainer(objectContext.DefaultContainerName, DataSpace.CSpace);
            foreach (var set in container.BaseEntitySets)
            {
                //if (set.ElementType.FullName.Contains(objectChange.TypeName)) might work better???
                if (set.ElementType.FullName.EndsWith(objectChange.TypeName, StringComparison.OrdinalIgnoreCase))
                    return Type.GetType(set.ElementType.FullName);
            }
        }
