    // size of chunk
    int chunkSize = 5;
    
    // dataset and table variables
    DataSet ds = GetDataSet();  // get your DataSet from somewhere
    DataTable source = ds.Tables[0], dest;
    
    // total rows
    int count = ds.Tables[0].Rows.Count;
    int tableCount = (count + 1) / chunkSize;
    
    // create tables (copy structure)
    for (int i = 0; i < tableCount; i++)
    {
        dest = source.Clone();
        dest.TableName = source.TableName + "_" + i.ToString();
        ds.Tables.Add(dest);
    }
    
    // fill tables
    int index = 0;
    foreach (DataRow row in source.Rows)
    {
        dest = ds.Tables[1 + index++ / chunkSize];
    
        // copy row (via copying item arrays)
        DataRow rowCopy = dest.NewRow();
        rowCopy.ItemArray = row.ItemArray;
        dest.Rows.Add(rowCopy);
    }
