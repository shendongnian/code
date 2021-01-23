    QueryExpression qe = new QueryExpression();
    qe.EntityName = "contact";
    qe.ColumnSet = new ColumnSet("fullname", "ownerid", "parentcustomerid", "new_title");
    qe.Criteria.AddCondition("ownerid", ConditionOperator.Equal, "0F040671-1E83-E111-83B9-D067E5EBE694");
    LinkEntity le = new LinkEntity();
    le.EntityAlias = "lm";  // note the alias, you need it when accessing fields of the linked entity
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
        // the linked (relationship) entity fields are of type AliasedValue
        AliasedValue av = listmember.GetAttributeValue<AliasedValue>("lm.listid");
        EntityReference lm = (EntityReference)av.Value;
        req.ListId = lm.Id;
        RemoveMemberListResponse resp = (RemoveMemberListResponse)service.Execute(req);
    }
