    QueryExpression qe = new QueryExpression("contact")
    {
        ColumnSet =  new ColumnSet("firstname", "lastname")
    };
    foreach (Entity entity in _organizationService.RetrieveMultiple(qe).Entities)
    {
        var copy = new Entity();
        copy["firstname'] = (entity.GetAttributeValue<string>("firstname") ?? "") + "(Copy)";
        _organizationService.Create(copy);
    }
