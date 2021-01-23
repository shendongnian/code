     private void trvAccountList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //This is a dummy node.
            trvAccountList.Nodes.Clear();
            SqlCommand sqlCMD1 = new SqlCommand("Select * From Customer Order by Account", sharedSqlConnection);
            try
            {
                SqlDataReader accountType = sqlCMD1.ExecuteReader();
                while (accountType.Read())
                {
                    TreeNode acctNode = new TreeNode(accountType["Account"].ToString());
                    acctNode.Nodes.Add(accountType["FirstName"].ToString());
                    acctNode.Nodes.Add(accountType["LastName"].ToString());
                    trvAccountList.Nodes.Add(acctNode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
