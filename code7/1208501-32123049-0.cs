    QueryByAttribute query = new QueryByAttribute("contact");
    query.ColumnSet = new ColumnSet("fullname", "emailaddress1");
    query.Attributes.AddRange("emailaddress1");
    query.Values.AddRange("test@test.com");
    EntityCollection retrieved = service.RetrieveMultiple(query);
