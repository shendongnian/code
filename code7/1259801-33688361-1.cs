    QueryExpression qe = new QueryExpression();
    qe.EntityName = "contact";
    qe.ColumnSet = new ColumnSet("fullname", "ownerid", "parentcustomerid", "new_title");
    qe.Criteria.AddCondition("ownerid", ConditionOperator.Equal, "0F040671-1E83-E111-83B9-D067E5EBE694");
    LinkEntity le = new LinkEntity();
    le.EntityAlias = "lm";
    le.Columns = new ColumnSet("listid");
    le.JoinOperator = JoinOperator.Inner;
    le.LinkFromEntityName = "contact";
    le.LinkFromAttributeName = "contactid";
    le.LinkToEntityName = "listmember";
    le.LinkToAttributeName = "entityid";
    eq.LinkEntities.Add(le);
    EntityCollection response = service.RetrieveMultiple(qe);
    // iterate over list members
    foreach (var listmember in response.Entities)
    {
        RemoveMemberListRequest req = new RemoveMemberListRequest();
        req.EntityId = listmember.Id;
        req.ListId = ((EntityReference)listmember.GetAttributeValue<AliasedValue>("lm.listid")).Id;
        RemoveMemberListResponse resp = (RemoveMemberListResponse)service.Execute(req);
    }
