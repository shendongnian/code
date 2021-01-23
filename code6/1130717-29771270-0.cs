    var metaResponse = (RetrieveEntityResponse)proxy.Execute(new RetrieveEntityRequest
    {
        EntityFilters = EntityFilters.Relationships,
        LogicalName = "account",
        RetrieveAsIfPublished = true
    });
    bool isActivityEnabled =
        metaResponse.EntityMetadata.OneToManyRelationships
        .Any(r => r.ReferencingEntity == "activitypointer");
