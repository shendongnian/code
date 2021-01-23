        public void showTipsTree(TreeView treeView1, TreeNodeMouseHoverEventArgs e, 
                    int imageindex, string tooltipField, string nameTable, string orginalField)
        {
            treeView1.ShowNodeToolTips = true;
            if (e.Node.SelectedImageIndex == imageindex)
            {
                string q = e.Node.ToString();
                SqlConnection conn = new SqlConnection(Connection1.x);
                conn.Open();
                string[] a = q.Split();
                SqlCommand cmd = new SqlCommand(String.Format(
         "select {1} from {2} where {3}={0}", a[1],tooltipField,nameTable,orginalField), conn);
                e.Node.ToolTipText = cmd.ExecuteScalar().ToString();
                conn.Close();
            }
        }
