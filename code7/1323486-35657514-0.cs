            string myConString = "Server=localHost;Database=fakekeeper;Uid=root;Pwd=**********;";
            string query = "SELECT OSP FROM OSP;";
            MySqlConnection conn = new MySqlConnection(myConString);
            MySqlDataReader reader;
            MySqlCommand cmd = new MySqlCommand(query, conn);
            conn.Open();
            reader = cmd.ExecuteReader();
            TreeNode tables = new TreeNode();
            treeView1.Nodes.Add(tables);
            while (reader.Read())
            {
                TreeNode alphaNode = new TreeNode(reader["OSP"].ToString());
                tables.Nodes.Add(alphaNode);
                MySqlConnection subNodeConn = new MySqlConnection(myConString);
                string subNodeQuery = string.Format("SELECT product FROM {0};", reader["OSP"].ToString());
                MySqlCommand subNodeCommand = new MySqlCommand(subNodeQuery, subNodeConn);
                MySqlDataReader subNodeReader;
                subNodeConn.Open();
                subNodeReader = subNodeCommand.ExecuteReader();
                while(subNodeReader.Read())
                {
                    alphaNode.Nodes.Add(subNodeReader["Product"].ToString());
                }
            }
            conn.Close();
