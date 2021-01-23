    public List<IDListItems> getIDList()
    {
        List<IDListItems> items = new List<IDListItems>();
        try
        {
            var x = (from c in db.ap_GetIDListItems()
                     select new IDListItems { CId = c.CID, Id = c.ID }).ToList();
            items = x;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return items;   
    }
