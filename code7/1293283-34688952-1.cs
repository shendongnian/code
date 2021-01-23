    TreeNode nodeSelected, nodeChild;
            nodeSelected = e.Node;
            SqlCommand sqlCMD1 = new SqlCommand("Select * From Customer Order by Account", sharedSqlConnection);
            //This is a dummy node.
            nodeSelected.Nodes.Clear();
            try
            {
                SqlDataReader accountType = sqlCMD1.ExecuteReader();
                while (accountType.Read())
                {
              
                    nodeChild = nodeSelected.Nodes.Add(accountType["Account"].ToString());
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
