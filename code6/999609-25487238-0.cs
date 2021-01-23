    string connString =  @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\...\myDB.mdb";
    using (var conn = new OleDbConnection(connString )) {
        conn.Open();
        DataTable schema = conn.GetSchema("Views", new string[] { null, null, "myQuery" });
        if (schema.Rows.Count > 0) {
            DataRow row = schema.Rows[0];
            string queryText = (string)row["VIEW_DEFINITION"];
            Console.WriteLine(queryText);
        }
    }
