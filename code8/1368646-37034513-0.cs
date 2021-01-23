    var query = PredicateBuilder.True<SearchResultItem>();
    query = query.And(i => i.Paths.Contains(homeItem.ID));
    query = query.And(i => i.Content.Contains(searchTerm));
    query = query.And(i => i.TemplateName != "MenuFolder");
    query = query.And(i => i.TemplateId != Sitecore.TemplateIDs.Folder);
