    [WebMethod]
    public static List<data> getSpareParts(string value)
    {
        using (var db = new WaltonCrmEntities())
        {
            return db.SpareParts.Select(x => new data
            {
                id = x.ItemID,
                text = x.ItemName
            }).ToList();
        }
    }
