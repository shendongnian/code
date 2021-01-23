    Action<IAliasFactory> productPartRecordAlias = x => x.ContentPartRecord<ProductPartRecord>().Named("productPartRecord");
    Action<IAliasFactory> titlePartRecordAlias = x => x.ContentPartRecord<TitlePartRecord>().Named("titlePartRecord");
    
    var query = _contentManager.HqlQuery()
        .Join(productPartRecordAlias)
        .Join(titlePartRecordAlias)
        .Where(a => a.ContentItem(), p => p.Gt("Id", "0 AND (productPartRecord.Price = 1000 OR titlePartRecord.Title = 'myTitle')"));
