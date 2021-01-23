    public static class MEFExtensions
    {
        public static IEnumerable<Lazy<T, M>> GetExportsResolved<T, M>(this CompositionContainer mefContainer,
                                                                       IUnityContainer unityContainer) 
            where T: class where M: class
        {
            // wrap the resolve around unity resolve then change type to T
            return mefContainer.GetExportTypesWithMetadata<T, M>()
                               .Select(kv => new Lazy<T, M>(() => unityContainer.Resolve(kv.Key) as T, kv.Value));
        }
        public static IEnumerable<KeyValuePair<Type, M>> GetExportTypesWithMetadata<T, M>(
            this CompositionContainer mefcontainer)
            where T : class where M : class
        {
            // need to examine each type to see if they have the correct export attribute and metadata
            foreach (var type in mefcontainer.GetExportTypes<T>())
            {
                // should just be one if more than one will throw exception
                // metadata or export attribute has to implement the interface
                var metadataAttribute =
                    type.GetCustomAttributes()
                        .SelectMany(
                            a =>
                            a.GetType()
                             .GetCustomAttributes()
                             .OfType<MetadataAttributeAttribute>()
                             .Concat<Attribute>(new[] { a }.OfType<ExportAttribute>()))
                        .OfType<M>().SingleOrDefault();
                // if we found the correct metadata
                if (metadataAttribute != null)
                {
                    // return the lazy factory
                    yield return new KeyValuePair<Type, M>(type, metadataAttribute);
                }
            }
        }
        //Idea from http://www.codewrecks.com/blog/index.php/2012/05/08/getting-the-list-of-type-associated-to-a-given-export-in-mef/
        public static IEnumerable<Type> GetExportTypes<T>(this CompositionContainer mefContainer)
            where T : class
        {
            // look in the mef catalog to grab out all the types that are of type T
            return mefContainer.Catalog.Parts.Where(part => part.ExportDefinitions
                                                                .Any(
                                                                    def =>
                                                                    def.Metadata.ContainsKey(
                                                                        "ExportTypeIdentity") &&
                                                                    def.Metadata["ExportTypeIdentity"]
                                                                        .Equals(
                                                                            typeof (T).FullName)))
                               .AsEnumerable()
                               .Select(part => ReflectionModelServices.GetPartType(part).Value);
        }
    }
