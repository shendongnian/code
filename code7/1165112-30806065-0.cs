    var qe = new QueryExpression {EntityName = "account", ColumnSet = new ColumnSet()};
    qe.ColumnSet.Columns.Add("name");
    qe.LinkEntities.Add(new LinkEntity("account", "contractdetail", "accountid", "accountid", JoinOperator.Inner));
    qe.LinkEntities[0].Columns.AddColumns("productid", "title");
    qe.LinkEntities[0].EntityAlias = "contractdetails";
               
    // Check Account State
    FilterExpression accountState = qe.Criteria.AddFilter(LogicalOperator.And);
    accountState.Conditions.Add(new ConditionExpression("statecode", ConditionOperator.Equal, 0));
    FilterExpression productFilter = qe.LinkEntities[0].LinkCriteria.AddFilter(LogicalOperator.Or);
    foreach (var product in products)
    {
        var condition = new ConditionExpression
        {
            AttributeName = "productid",
            Operator = ConditionOperator.Equal
        };
        condition.Values.Add(product.ProductId);
        productFilter.Conditions.Add(condition); 
    }                
    EntityCollection resultsCollection = _OrgService.RetrieveMultiple(qe);
