    public override ODataEntry CreateEntry(SelectExpandNode selectExpandNode, EntityInstanceContext entityInstanceContext)
    {
        ODataEntry entry = base.CreateEntry(selectExpandNode, entityInstanceContext);
   
        // Remove any properties which are null.
        List<ODataProperty> properties = new List<ODataProperty>();
        foreach (ODataProperty property in entry.Properties)
        {
            if (property.Value != null)
            {
                properties.Add(property);
            }
        }
        entry.Properties = properties;
        return entry;
    }
