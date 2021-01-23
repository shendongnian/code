    static IEdmModel GetCodeFirstEdm<T>(this T dbContext)  where T : DbContext
    {
        // create the XmlDoc from the EF metadata
        XmlDocument metadataDocument = new XmlDocument();
        using (var stream = new MemoryStream())
        using (var writer = XmlWriter.Create(stream))
        {
            System.Data.Entity.Infrastructure.EdmxWriter.WriteEdmx(dbContext, writer);
            stream.Position = 0;
            metadataDocument.Load(stream);
        }
        // to support proper xpath queries
        var nsm = new XmlNamespaceManager(metadataDocument.NameTable);
        nsm.AddNamespace("ssdl", "http://schemas.microsoft.com/ado/2009/02/edm/ssdl");
        nsm.AddNamespace("edmx", "http://schemas.microsoft.com/ado/2009/11/edmx");
        nsm.AddNamespace("edm", "http://schemas.microsoft.com/ado/2009/11/edm");
            
        // find the node we want to work with & add the 1..N property metadata
        var typeElement = metadataDocument.SelectSingleNode("//edmx:Edmx/edmx:Runtime/edmx:ConceptualModels/edm:Schema/edm:EntityType[@Name=\"Request\"]", nsm);
            
        // effectively, we want to insert this.
        // <Property Name="UserName" Type="String" MaxLength="1000" FixedLength="false" Unicode="true" Nullable="true" />
        var propElement = metadataDocument.CreateElement(null, "Property", "http://schemas.microsoft.com/ado/2009/11/edm");
        propElement.SetAttribute("Name", "UserName");
        propElement.SetAttribute("Type", "String");
        propElement.SetAttribute("FixedLength", "false");
        propElement.SetAttribute("Unicode", "true");
        propElement.SetAttribute("Nullable", "true");
        // append the node to the type element
        typeElement.AppendChild(propElement);
        // now we're going to save the updated xml doc and parse it.
        using (var stream = new MemoryStream())
        {
            metadataDocument.Save(stream);
            stream.Position = 0;
            using (var reader = XmlReader.Create(stream))
            {
                return EdmxReader.Parse(reader);
            }
        }
    }
