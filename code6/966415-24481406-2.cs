    private void removeBTN_Click(object sender, EventArgs e)
        {
            string tableName = Data["Quotation Name"].ToString().Trim(); //gets the table name 
            if (MessageBox.Show("Are you sure you want to remove this item? ", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (DataGridViewRow r in quotation_NameDataGridView.SelectedRows)
                {
                    string constring = @"Data Source=|DataDirectory|\LWADataBase.sdf";
                    string Query = "delete from [" + tableName + "] where [Item Name] like @item";
                    SqlCeConnection conDataBase = new SqlCeConnection(constring);
                    SqlCeCommand cmd = new SqlCeCommand(Query, conDataBase);
                    if (r.Cells[0] != null)
                    {
                       
                        cmd.Parameters.Add("@item", r.Cells[0].Value.ToString());
                        try
                        {
                            conDataBase.Open();
                            int res = cmd.ExecuteNonQuery();
                            conDataBase.Close();
                            //displays a system error message if a problem is found
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    getTable(); //loads the table into the DGV
                }
            }
        }
