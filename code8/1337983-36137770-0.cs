            static public void showTipsTree(TreeView treeView1, string tooltipField_toMainNodes, string nameTable_toMainNodes, string orginalField_toMainNodes, string tooltipField_toSubNodes, string nameTable_toSubNodes, string orginalField_toSubNodes)
        {
            treeView1.ShowNodeToolTips = true;
            SqlConnection conn = new SqlConnection(Connection1.x);
            conn.Open();
            for (int i = 0; i < treeView1.Nodes.Count; i++)
            {
                string[] a = treeView1.Nodes[i].ToString().Split();
                SqlCommand cmd = new SqlCommand(String.Format("select {0} from {1} where {2}={3}", tooltipField_toMainNodes, nameTable_toMainNodes, orginalField_toMainNodes, a[1]), conn);
                treeView1.Nodes[i].ToolTipText = cmd.ExecuteScalar().ToString();
                for (int j = 0; j < treeView1.Nodes[i].Nodes.Count; j++)
                {
                    string[] a2 = treeView1.Nodes[i].Nodes[j].ToString().Split();
                    SqlCommand cmd2 = new SqlCommand(String.Format("select {0} from {1} where {2}={3}", tooltipField_toSubNodes, nameTable_toSubNodes, orginalField_toSubNodes, a2[1]), conn);
                    treeView1.Nodes[i].Nodes[j].ToolTipText = cmd2.ExecuteScalar().ToString();
                }
            }
            conn.Close();
        }
