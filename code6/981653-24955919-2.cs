    OleDbDataAdapter da = new OleDbDataAdapter(.....)
    DataTable dt = new DataTable();
    da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
    da.Fill(dt);
    // Just for testing
    // Check these results with and without the MissingSchemaAction flag
    Console.WriteLine(dt.Rows.Count);
    da.Fill(dt);
    Console.WriteLine(dt.Rows.Count);
