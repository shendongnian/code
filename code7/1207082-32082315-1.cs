    public DataTable JoinAndUpdate(DataTable tbl1, DataTable tbl2)
    {
        // for demo purpose I have created a clone of tbl1.
        // you can define a custom schema, if needed.
        DataTable dtResult = tbl1.Clone();
    
        var result = from dataRows1 in tbl1.AsEnumerable()
                     join dataRows2 in tbl2.AsEnumerable()
                     on dataRows1.Field<int>("ID") equals dataRows2.Field<int>("ID") into lj
                     from reader in lj
                     select new object[]
                      {
                        dataRows1.Field<int>("ID"), // ID from table 1
                        reader.Field<string>("name2"), // Updated column value from table 2
                        dataRows1.Field<int>("age")
                        // .. here comes the rest of the fields from table 1.
                      };
    
        // Load the results in the table
        result.ToList().ForEach(row => dtResult.LoadDataRow(row, false));
    
        return dtResult;
    }
