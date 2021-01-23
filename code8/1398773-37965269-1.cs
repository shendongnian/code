    public void ChangeConnection(SystemToDatabaseMapping SystemToDatabaseMapping)
    {
        var entityConnection = EntityConnectionExtensions.Create(
            new List<DatabaseSpecificModification> { new DatabaseSpecificModification("QUOTE_HOUSE", "UPRN",false), new DatabaseSpecificModification("QUOTE_HOUSE", "INSIGHT_DATA", false)},
            sagaSystemToDatabaseMapping.ConnectionString, "Ecom.Ecom");
        this.DbContext = new EcomEntities(entityConnection);
    ....
    }
    public static class EntityConnectionExtensions
    {
        public static IEnumerable<XElement> ElementsAnyNS<T>(this IEnumerable<T> source, string localName)
    where T : XContainer
        {
            return source.Elements().Where(e => e.Name.LocalName == localName);
        }
        public static IEnumerable<XElement> ElementsAnyNS(this XContainer source, string localName)
        {
            return source.Elements().Where(e => e.Name.LocalName == localName);
        }
        public static EntityConnection Create(
            List<DatabaseSpecificModification> tableAndColumn, string connString, string model)
        {
            var conceptualReader = XmlReader.Create(
                Assembly
                    .GetExecutingAssembly()
                    .GetManifestResourceStream(model + ".csdl")
                );
           var mappingReader =XmlReader.Create(
                Assembly
                    .GetExecutingAssembly()
                    .GetManifestResourceStream(model + ".msl")
                );
            var storageReader = XmlReader.Create(
                Assembly
                    .GetExecutingAssembly()
                    .GetManifestResourceStream(model + ".ssdl")
                );
            var conceptualXml = XElement.Load(conceptualReader);
            var mappingXml = XElement.Load(mappingReader);
            var storageXml = XElement.Load(storageReader);
            Action<XElement> removeNodes = (element) =>
            {
                if (element.Attribute("Name") != null && tableAndColumn.Any(oo => oo.Table == element.Attribute("Name").Value && !oo.IsAdd) || element.Attribute("StoreEntitySet") != null && tableAndColumn.Any(oo => oo.Table == element.Attribute("StoreEntitySet").Value && !oo.IsAdd))
                {
                    var matchingSelectParts = tableAndColumn.Where(oo => element.Value.Contains(string.Format("\"{0}\".\"{1}\" AS \"{1}\"", oo.Table, oo.Column)) && !oo.IsAdd);
                    if (matchingSelectParts.Any())
                    {
                        foreach (var matchingSelectPart in matchingSelectParts)
                        {
                            var definingQuery = element.ElementsAnyNS("DefiningQuery").Single();
                            definingQuery.Value = definingQuery.Value.Replace(string.Format(", \n\"{0}\".\"{1}\" AS \"{1}\"", matchingSelectPart.Table, matchingSelectPart.Column), "");
                        }
                    }
                    else
                    {
                        var nodes = element.Nodes()
                            .Where(o =>
                                o is XElement
                                && ((XElement) o).Attribute("Name") != null
                                && tableAndColumn.Any(oo => ((XElement) o).Attribute("Name").Value == oo.Column && !oo.IsAdd));
                        foreach (var node in nodes.ToList())
                        {
                            node.Remove();
                        }
                    }                   
                }
            };
            foreach (var entitySet in storageXml.Elements())
            {
                if (entitySet.Attribute("Name").Value == "ModelStoreContainer")
                {
                    foreach (var entityContainerEntitySet in entitySet.Elements())
                    {
                        removeNodes(entityContainerEntitySet);
                    }
                }
                removeNodes(entitySet);
            }
            foreach (var entitySet in conceptualXml.Elements())
            {
                if (entitySet.Attribute("Name").Value == "ModelStoreContainer")
                {
                    foreach (var entityContainerEntitySet in entitySet.Elements())
                    {
                        removeNodes(entityContainerEntitySet);
                    }
                }
                removeNodes(entitySet);
            }
            foreach (var entitySet in mappingXml.Elements().ElementAt(0).Elements())
            {
                if (entitySet.Name.LocalName == "EntitySetMapping")
                {
                    foreach (var entityContainerEntitySet in entitySet.Elements().First().Elements())
                    {
                        removeNodes(entityContainerEntitySet);
                    }
                }
                removeNodes(entitySet);
            }
            storageXml.CreateReader();
            StoreItemCollection storageCollection =
                new StoreItemCollection(
                    new XmlReader[] {storageXml.CreateReader()}
                    );
            EdmItemCollection conceptualCollection = new EdmItemCollection(new []{conceptualXml.CreateReader()});
            StorageMappingItemCollection mappingCollection =
                new StorageMappingItemCollection(
                    conceptualCollection, storageCollection, new []{ mappingXml.CreateReader()}
                    );
            var workspace = new MetadataWorkspace();
           
            workspace.RegisterItemCollection(conceptualCollection);
            workspace.RegisterItemCollection(storageCollection);
            workspace.RegisterItemCollection(mappingCollection);
            var connectionData = new EntityConnectionStringBuilder(connString);
            var connection = DbProviderFactories
                .GetFactory(connectionData.Provider)
                .CreateConnection();
            connection.ConnectionString = connectionData.ProviderConnectionString;
            return new EntityConnection(workspace, connection);
        }
    }
    public class DatabaseSpecificModification
    {
        public DatabaseSpecificModification(string table, string column, bool isAdd)
        {
            Table = table;
            Column = column;
            IsAdd = isAdd;
        }
        public string Table { get; set; }
        public string Column { get; set; }
        public bool IsAdd { get; set; }
    }
