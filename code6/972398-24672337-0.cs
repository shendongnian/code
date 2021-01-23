    public List<IDListItems> getIDList()
    {
        return (from c in db.ap_GetIDListItems()
                select new IDListItems { CId = c.CID, Id = c.ID }).ToList();
    }
