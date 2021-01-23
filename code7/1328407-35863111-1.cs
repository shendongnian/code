    static DataTable CompareDataTables(DataTable dt1, DataTable dt2)
    {
        var keyName = dt1.Columns.Cast<DataColumn>().Single (x => x.Unique).ColumnName;
        var dt1Cols = dt1.Columns.Cast<DataColumn>().Where (x => !x.Unique).Select (x =>x.ColumnName );
        var dt2Cols = dt1.Columns.Cast<DataColumn>().Where (x => !x.Unique).Select (x =>x.ColumnName );
        
        // get keys from both data tables
        var keys = new HashSet<int>(dt1.AsEnumerable().Select (x => (int)x[keyName]));
        keys.UnionWith(dt2.AsEnumerable().Select (x => (int)x[keyName]));
        
        keys.Dump("keys");
        
        // create a new data table that will hold the results
        var result = new DataTable();
        result.Columns.Add(keyName, typeof(int));
        result.Columns[0].Unique = true;
        
        // initialize data and comparison columns
        foreach (var name in dt1Cols)
        {
            result.Columns.Add(name + "_off", dt1.Columns[name].DataType);
            result.Columns.Add(name + "_on", dt1.Columns[name].DataType);
            result.Columns.Add(name + "_same", typeof(bool), name + "_off = " + name + "_on");
        } 
        
        foreach (var key in keys)
        {
            // get a row from each data table with the current key
            var rowOff = dt1.Select(keyName + " = " + key).FirstOrDefault();
            var rowOn = dt2.Select(keyName + " = " + key).FirstOrDefault();
            // create a new row            
            var newRow = result.NewRow();
            // fill the new row with off data
            if (rowOff != null)
            {
                newRow[keyName] = rowOff[keyName];
                foreach (var name in dt1Cols)
                {
                    newRow[name + "_off"] = rowOff[name];
                }
            }
            
            // fill the new row with on data
            if (rowOn != null)
            {
                foreach (var name in dt1Cols)
                {
                    newRow[name + "_on"] = rowOn[name];
                }
                newRow[keyName] = rowOn[keyName];
            }
            
            // add the row to the result data table
            result.Rows.Add(newRow);        
        }
        
        return result;
    }
