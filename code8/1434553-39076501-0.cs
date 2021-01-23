    for (int i = 0; i <= dst.Tables[0].Rows.Count - 1; i++)
                {
                    nodeTables.Nodes.Add(dst.Tables[0].Rows[i]["SchemaName"].ToString() + "." + dst.Tables[0].Rows[i]["TableName"].ToString());
                    nodeTables.Nodes[i].ImageIndex = 2;
                    nodeTables.Nodes[i].Nodes.Add("Columns");
                    
                    //Filling the Column Names
                    DataSet dstCol = new DataSet();
                    dstCol = common.GetColumns(Convert.ToInt32(dst.Tables[0].Rows[i]["object_Id"]));
    
                    for (int col = 0; col <= dstCol.Tables[0].Rows.Count - 1; col++)
                    {
                        nodeTables.Nodes[i].Nodes[0].ImageIndex = 0;
                        nodeTables.Nodes[i].Nodes[0].Nodes.Add(dstCol.Tables[0].Rows[col]["name"].ToString());
                        nodeTables.Nodes[i].Nodes[0].Nodes[col].ImageIndex = 1;
                    }
                }
