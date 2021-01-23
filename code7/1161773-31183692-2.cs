    FilterExpression humanFilter = new FilterExpression();
    humanFilter.AddCondition(new ConditionExpression("createdby", ConditionOperator.NotNull));
    
    if (retrieveAdminUser)
    {
      humanFilter.FilterOperator = LogicalOperator.Or;
      humanFilter.AddCondition(
        new ConditionExpression("domainname", ConditionOperator.Equal, "admin@crm"));
    }
    
    userQuery.Criteria.AddFilter(humanFilter);
