    string connString =  @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\...\myDB.mdb";
    using (var conn = new OleDbConnection(connString )) {
        conn.Open();
        string restrictions = new string[] { null, null, "myQuery" };
        DataTable schema = conn.GetSchema("Views", restrictions);
        if (schema.Rows.Count > 0) {
            DataRow row = schema.Rows[0];
            string queryText = (string)row["VIEW_DEFINITION"];
            Console.WriteLine(queryText);
        }
    }
