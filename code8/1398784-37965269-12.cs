    public void ChangeConnection(SystemToDatabaseMapping systemToDatabaseMapping)
    {  
        if (systemToDatabaseMapping.ColumnsToRemove != null)
            {
                var entityConnection = EntityConnectionExtensions.Create(
                    new List<ColumnsToRemove> { new ColumnsToRemove("QUOTE_HOUSE", "UPRN"), new ColumnsToRemove("QUOTE_HOUSE", "INSIGHT_DATA") },
                    systemToDatabaseMapping.ConnectionString);
                this.Ecom = new EcomEntities(entityConnection);
            }
            else
            {
                this.Ecom = new EcomEntities(systemToDatabaseMapping.ConnectionString);
            }
     ....
    }
