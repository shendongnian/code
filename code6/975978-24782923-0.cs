    public async Task<DateTime> GetLatestModifiedDateAsync<T>(String fieldName) where T : new()
        {
            var propertyInfo = typeof(T).GetProperty(fieldName);  
    
            var result = await db.Table<T>()
                                 .OrderByDescending(e => propertyInfo.GetValue(e, null) )
                                 .FirstOrDefaultAsync();
    
            return result.ModifiedAt;
        }
 
