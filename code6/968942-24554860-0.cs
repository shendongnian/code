    EntityCollection result = service.RetrieveMultiple(new FetchExpression(fetchxml)); 
    foreach (var c in result.Entities)
    {
        if (result != null && result.Entities.Count > 0)
        {
            List<string> _products = new List<string>();
            foreach (Entity _entity in result.Entities)
            {
                string productid = (EntityReference)c.Attributes["productid"]).Name.ToString();
                string quantity = _entity.Attributes["quantity"].ToString();
                CSVFILE = productid + "," + quantity;
                //Write CSVFILE
                //...
            }
        }
    }
