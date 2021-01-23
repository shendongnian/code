    using (OleDbConnection OleDBConnection = new OleDbConnection())
    {
        OleDBConnection.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
            "Data Source=" + databaseLocation + ";Persist Security Info=False;";
        try
        {
            OleDBConnection.Open();
            string[] restrictions2 = new string[] { null, null, null, "TABLE" };
            System.Data.DataTable DataTable2 = OleDBConnection.GetSchema("Tables", restrictions2);
            // clear the treeview
            treeView1.Nodes.Clear();
            // here I tried to populate the treeview but have failed
            foreach (System.Data.DataRow row in DataTable2.Rows)
            {
                // add parent node -> table name
                var parent = treeView1.Nodes.Add(row["TABLE_NAME"].ToString());
                // now add children -> all table columns
                string[] restrictions1 = new string[] { null, null, (string)row["TABLE_NAME"], null };
                System.Data.DataTable DataTable1 = OleDBConnection.GetSchema("Columns", restrictions1);
                foreach (DataRow row1 in DataTable1.Rows)
                {
                    parent.Nodes.Add((string)row1["COLUMN_NAME"]);
                }
            }
            // all done, close the connection
            OleDBConnection.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
            Application.Exit();
        }
    }
