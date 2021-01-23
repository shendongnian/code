    public void ChangeConnection(SystemToDatabaseMapping SystemToDatabaseMapping)
    {
        var entityConnection = EntityConnectionExtensions.Create(
            new List<DatabaseSpecificModification> { new DatabaseSpecificModification("QUOTE_HOUSE", "UPRN"), new DatabaseSpecificModification("QUOTE_HOUSE", "INSIGHT_DATA")},
            sagaSystemToDatabaseMapping.ConnectionString, "Ecom.Ecom");
        this.DbContext = new EcomEntities(entityConnection);
    ....
    }
