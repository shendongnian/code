    var g = Guid.NewGuid() //Replace this with your actual Id from the query
    Queryexpression query = new QueryExpression { Entityname = "new_customentity", 
    Columnset = new Columnset("new_customentityid")};
    query.Criteria.AddCondition("new_customentityid", ConditionalOperator.Equal, g);
    Entity Collection result = service.RetrieveMultiple(query)
