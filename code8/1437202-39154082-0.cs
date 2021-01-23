    public System.ServiceModel.Channels.Message GetInventory(string itemID)
    {
        inventoryQuery = string.Format(inventoryQuery, itemID);
        string queryResult = _sub.Database.SqlQuery<string>(inventoryQuery).FirstOrDefault();
        return WebOperationContext.Current.CreateTextResponse(queryResult,"text/xml");
    }
