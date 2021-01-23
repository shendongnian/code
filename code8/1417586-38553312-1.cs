    private void PopulateTreeView(DataTable dtParent, int parentId, TreeNode treeNode)
        {
            foreach (DataRow row in dtParent.Rows)
            {
                string Value = string.Empty;
                string header = string.Empty;
                // Get all columns name
                for (var i=0;i<(dtParent.Columns.Count)-1;i++)
	            {
                    header += dtParent.Columns[i].ColumnName + "  ";
	            }
                TreeNode headerNode = new TreeNode
                {
                    Text = header.ToString(),
                     // Any value that you want and has no confelict with other
                    Value = row["Id"].ToString()
                };
                if (dtParent.Columns.Count > 2)
                {
                    Value += row["Name"].ToString() + " " + " ";
                    Value += row["VehicleType"].ToString() + " " + " ";
                    Value += row["Capacity"].ToString() + " " + " ";
                }
                else
                {
                    Value += row["Name"].ToString() + " " + " ";
                }
                TreeNode child = new TreeNode
                {
                    Text = Value.ToString(),
                    Value = row["Id"].ToString()
                };
                if (parentId == 0)
                {
                    TreeView1.Nodes.Add(child);
                    DataTable dtChild = this.GetData("SELECT Id, Name,VehicleType,Capacity FROM Bikes WHERE VehicleTypeId = " + child.Value);
                    PopulateTreeView(dtChild, int.Parse(child.Value), child);
                }
                else
                {
                    treeNode.ChildNodes.Add(child);
                }
            }
        }
