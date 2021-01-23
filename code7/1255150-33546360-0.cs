    List<SomeClass> ret = new List<SomeClass>();
    foreach (DataTable table in ds.Tables)
    {
        foreach (DataRow row in table.Rows)
        {
            SomeClass FR = new SomeClass(); // <--- right here
            if (String.IsNullOrEmpty(FR.v) || FR.v != row["v"])
            {
                FR.v = row["v"].ToString();
            }
            if (String.IsNullOrEmpty(FR.y) || FR.y != row["y"])
            {
                FR.y = row["y"].ToString();
            }
    
            ret.Add(FR);
        }
    }
