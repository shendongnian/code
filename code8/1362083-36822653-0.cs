    [WebMethod]
    public static List<data> getSpareParts(string value)
    {
        using (var db = new WaltonCrmEntities())
        {
            List<data> spareParts = db.SpareParts.Select(x => new data
            {
                id = x.ItemID,
                text = x.ItemName
            }).ToList();
            return spareParts;
        }
    }
