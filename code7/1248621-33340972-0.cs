    private readonly IOrganizationService _service;
    public Entity GetFullInvoice(Guid invoiceId)
    {
        var request = new RetrieveRequest
        {
            ColumnSet = new ColumnSet(allColumns: true),
            Target = new EntityReference("invoice", invoiceId),
            RelatedEntitiesQuery = new RelationshipQueryCollection()
        };
        var relation = new Relationship("invoice_details");
        relation.PrimaryEntityRole = EntityRole.Referenced;
        var invoiceDetailQuery = new QueryExpression("invoicedetail");
        invoiceDetailQuery.ColumnSet = new ColumnSet(allColumns: true);
        invoiceDetailQuery.Criteria.AddCondition("invoiceid", ConditionOperator.Equal, invoiceId);
        var result = (RetrieveResponse)_service.Execute(request);
        return result.Entity;
    }
