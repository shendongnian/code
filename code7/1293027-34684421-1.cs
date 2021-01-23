    public void QuickUpdate(Record original)
    {
        Record updatedRecord = _dbSet.Records.FirstOrDefault(r => r.Id == original.Id);
        updateRecord.IsDeleted = true;
        _dbSet.SaveChanges();
    }
