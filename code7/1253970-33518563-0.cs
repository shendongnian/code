    private void DeleteFamBtn_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> selectedRows = (from row in DataGridViewFamille.Rows.Cast<DataGridViewRow>()
                                                  where Convert.ToBoolean(row.Cells["checkBoxColumn"].Value) == true
                                                  select row).ToList();
            
            if (MessageBox.Show(string.Format("Do you want to delete {0} rows?", selectedRows.Count), "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //delete Nature de Charge before delete Famille
                foreach (DataGridViewRow row in selectedRows)
                {
                    int aa = Convert.ToInt32(row.Cells["IdFam"].Value);
                    conn = new SqlConnection(connstring);
                    conn.Open();
                    comm = new SqlCommand("DELETE FROM NAtureCharge WHERE IdFam ='" + aa + "'", conn);
                    try
                    {
                        comm.ExecuteNonQuery();
                        //MessageBox.Show("Deleted...");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Not Deleted");
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
                //Delete Famille
                foreach (DataGridViewRow row in selectedRows)
                {
                    using (SqlConnection con = new SqlConnection(connstring))
                    {
                        using (SqlCommand cmd = new SqlCommand("DELETE FROM Famille WHERE IdFam = @IdFam", con))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@IdFam", row.Cells["IdFam"].Value);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                }
                //Update the datagridview
                this.BindGrid();
            }
        }
