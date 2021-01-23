    SqlDataAdapter da = new SqlDataAdapter("Select * from testTable", con);
    IEnumerable<int> results = new string[]
    {
        "DT1", "DT2", "DT3", "DT4", "DT5"
    }
    .AsParallel()
    .Select((table, index) => da.Fill(ds, 
                              numberOfRowsToPutInEachDataTable * index, 
                              numberOfRowsToPutInEachDataTable, 
                              table));
