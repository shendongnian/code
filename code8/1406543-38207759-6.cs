    [Route("multilanguage/Resources")]
    [HttpPut]
    public async Task<IHttpActionResult> UpdateResource([FromBody] resourceClass obj)
    {
        client = new DocumentClient(new Uri(EndPoint), AuthKey);
        var collectionLink = UriFactory.CreateDocumentCollectionUri(DatabaseId, CollectionId);
    
        var query = new SqlQuerySpec("SELECT * FROM MultiLanguage as m where m.id = @pmId", 
        new SqlParameterCollection(new SqlParameter[] { new SqlParameter { Name = "@pmId", Value = Id } }));
    
        Document doc = client.CreateDocumentQuery<Document>(
                collectionLink, query).AsEnumerable().FirstOrDefault();
    
        List<Models.Translations> d = doc.GetPropertyValue<List<Models.Translations>>("Translations");
        Models.Translations temp = d.Find(p => p.Language == Language);
    
        temp.Content = text;
        temp.LastModified = DateTimeOffset.Now;
        temp.ModifiedBy = "admin";
        doc.SetPropertyValue("Translations", d);
    
        Document updated = await client.ReplaceDocumentAsync(doc);
    
        return Ok();
    }
