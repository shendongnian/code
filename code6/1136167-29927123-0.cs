        // get database schema
        DataTable tableTable = OleDBConnection.GetSchema("Tables");
        DataTable columnsTable = OleDBConnection.GetSchema("Columns");
        // clear the treeview
        tree.Nodes.Clear();
        // for each table
        foreach (System.Data.DataRow row in tableTable.Rows)
        {
            // add parent node -> table name
            string tableName = row["TABLE_NAME"].ToString();
            if (!tableName.StartsWith("MSys"))
            {
                tree.Nodes.Add(tableName);
                // now add children -> all table columns
                foreach (System.Data.DataRow columnRow in columnsTable.Rows)
                {
                    if (columnRow["TABLE_NAME"].ToString().Equals(tableName))
                    {
                        tree.Nodes.Add(columnRow["COLUMN_NAME"].ToString());
                    }
                }
            }
        }
