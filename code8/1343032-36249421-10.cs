    public void SaveLeadsForBuyer(ISenderModel model)
    {
        // ... code ...
        // _unit.SaveChanges();
        _unit.BulkSaveChanges();
    }
