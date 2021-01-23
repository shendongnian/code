    var cb = new ConventionBuilder();
    cb.ForTypesDerivedFrom<IHttpController>()
                .AddPartMetadata(MetadataApiControllerName, t => t.FullName)
                .Export(ex => ex.AddMetadata(MetadataApiControllerName, t => t.FullName))
                .ExportInterfaces();
    cb.ForTypesMatching(t => t.BaseType != null && (
                        (t.BaseType.Name.Equals(MetadataControllerName) && !t.BaseType.Name.StartsWith("T4MVC"))
                        || t.BaseType.Name.Equals(MetadataExtentionControllerName)
                        ))
                    .AddPartMetadata(MetadataControllerName, t => t.FullName)
                    .Export(ex => ex.AddMetadata(MetadataControllerName, t => t.FullName))
                    .ExportInterfaces();
