    string fetch = "<fetch xml string>"
    var query = new FetchExpression(fetch);
    var request = new RetrieveMultipleRequest();
    request.Query = query;
    var entities = ((RetrieveMultipleResponse)service.Execute(request)).EntityCollection.Entities;
    foreach (var entity in entities)
    {
        Console.WriteLine(entity.GetAttributeValue<string>("subject"));
    }
