    public void populateListView()
                {
                    lbxBugged.Items.Clear();
                    SqlCeCommand cm = new SqlCeCommand("SELECT Bug_ID, Bug_Code, Bug_Description, Bug_Author FROM tblBugs ORDER BY Bug_ID ASC", mySqlConnection);
        
                    try
                    {
                        mySqlConnection.Open();
                        SqlCeDataReader dr = cm.ExecuteReader();
                        while (dr.Read())
                        {
                            ListViewItem item = new ListViewItem(dr["Bug_ID"].ToString());
                            item.SubItems.Add(dr["Bug_Code"].ToString());
                            item.SubItems.Add(dr["Bug_Description"].ToString());
                            item.SubItems.Add(dr["Bug_Author"].ToString());
        
                            lbxBugged.Items.Add(item);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error");
                    }
        
                    
                } 
