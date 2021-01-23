    public void QuickUpdate(T original)
    {
        Record updatedRecord = _dbSet.Records.FirstOrDefault(r => r.Id == updated.Id);
        updateRecord.IsDeleted = true;
        _dbSet.SaveChanges();
    }
