        public static TreeView PopulateTreeViewWithSchema(System.Data.OleDb.OleDbConnection conn, TreeView tree)
        {
            if (tree == null)
                tree = new TreeView();
            // get database schema
            DataTable tableTable = conn.GetSchema("Tables");
            DataTable columnsTable = conn.GetSchema("Columns");
            // clear the treeview
            tree.Nodes.Clear();
            // here I tried to populate the treeview but have failed
            foreach (System.Data.DataRow row in tableTable.Rows)
            {
                // add parent node -> table name
                string tableName = row["TABLE_NAME"].ToString();
                if (!tableName.StartsWith("MSys"))
                {
                    TreeNode node = new TreeNode(tableName);
                    tree.Nodes.Add(node);
                    // now add children -> all table columns
                    foreach (System.Data.DataRow columnRow in columnsTable.Rows)
                    {
                        if (columnRow["TABLE_NAME"].ToString().Equals(tableName))
                        {
                            node.Nodes.Add(columnRow["COLUMN_NAME"].ToString());
                        }
                    }
                }
            }
            return tree;
        }
