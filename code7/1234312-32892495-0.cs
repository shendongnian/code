    QueryExpression productBundleQuery = new QueryExpression();
    productBundleQuery.Distinct = false;
    productBundleQuery.EntityName = "productassociation";
    productBundleQuery.ColumnSet = new ColumnSet("associatedproduct");
    productBundleQuery.Criteria = new FilterExpression
    {
         Conditions = { new ConditionExpression("productid", ConditionOperator.Equal, bundle.Id) }
    };
    EntityCollection productBundleCollection = _service.RetrieveMultiple(productBundleQuery);
    foreach (Entity productAssociation in productBundleCollection.Entities)
    {
        Entity product = _service.Retrieve("product", ((EntityReference)productAssociation["associatedproduct"]).Id, new ColumnSet("name", ...));
        Do something....
     }
