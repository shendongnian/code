    private static readonly Guid AdminRoleTemplateId = new Guid("627090FF-40A3-4053-8790-584EDC5BE201");
    public bool HavingAdminRole(Guid systemUserId)
    {
        var query = new QueryExpression("role");
        query.Criteria.AddCondition("roletemplateid", ConditionOperator.Equal, AdminRoleTemplateId);
        var link = query.AddLink("systemuserroles", "roleid", "roleid");
        link.LinkCriteria.AddCondition("systemuserid", ConditionOperator.Equal, systemUserId);
        return _service.RetrieveMultiple(query).Entities.Count > 0;
    }
