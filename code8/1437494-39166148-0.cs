    public IEnumerable<TestUploadData2> GetPagedData(string prop1SearchValue,
                                                     string prop2SearchValue,
                                                     int pageNum = 1,
                                                     int pageSize = 20)
    {
        var data = db.TestUploadData2;
        // No idea what your properties are, so I'll just wing with strings.
        if (!string.IsNullOrWhitespace(prop1SearchValue))
        {
            data = data.Where(d => d.Prop1 == prop1SearchValue);
        }
        // Did it like this so you can see how to conditionally filter the query
        if (!string.IsNullOrWhitespace(prop2SearchValue))
        {    
            data = data.Where(d => d.Prop2 == prop2SearchValue);
        }
                   // If it is the first page, then 0 * pageSize,
                   // second page, skip 1 * pageSize, etc.
        return data.Skip((pageNum - 1) * pageSize)
                   // Take only what is being asked for.
                   .Take(pageSize)
                   // NOW pull it from the database.
                   .ToList();
    }
    
