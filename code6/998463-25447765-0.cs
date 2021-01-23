    private void CreateRecord(Record data)
    {
         // Update
         _dbSet.Attached(data); 
         context.Entry(data).State = EntityState.Modified;   
    
        // Insert Copy
        var newData = new Record();
        newData.Name = data.Name;
        _dbSet.Add(newData);
    
        context.SaveChanges();
    }
