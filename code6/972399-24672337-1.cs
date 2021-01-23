    public List<IDListItems> getIDList()
    {
        return db.ap_GetIDListItems()
                 .Select(c => new IDListItems { CId = c.CID, Id = c.ID })
                 .ToList();
    }
