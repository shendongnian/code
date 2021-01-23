    // At the top:
    List<List<object>> data = new List<List<object>>();
    // Lower:
    while (reader.Read())
    {
        List<object> row = new List<object>();
        for (int i = 0; i < reader.FieldCount; i++)
        {
            object val = reader.GetValue(i);
            Console.WriteLine(val);
            row.Add(val);
        }
        data.Add(row);
        // You can now use the row variable here if you want, or you can
        //    wait until after looping through the reader and send the
        //    emails at the end, using the data variable instead.
        
        Console.WriteLine();
    }
