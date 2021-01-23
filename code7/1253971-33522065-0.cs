    private void DeleteFamBtn_Click(object sender, EventArgs e)
    {
        List<DataGridViewRow> selectedRows = (from row in DataGridViewFamille.Rows.Cast<DataGridViewRow>()
                                              where Convert.ToBoolean(row.Cells["checkBoxColumn"].Value)
                                              select row).ToList();
    
    
        if (MessageBox.Show(string.Format("Do you want to delete {0} rows?", selectedRows.Count), "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
        {
            //delete Nature de Charge before delete Famille
            var idsToDelete = selectedRows.Select(row => row.Cells["IdFam"].Value).ToList();
            try
            {
                using (var con = new SqlConnection(connstring))
                {
                	var ids = string.Join(",", idsToDelete);
                    using (var deleteNatures = new SqlCommand("DELETE FROM NatureCharge IdFam IN " + ids, con))
                    using (var deleteFamilles = new SqlCommand("DELETE FROM Famille WHERE Id IN " + ids, con))
                    {
                        deleteNatures.Parameters.AddWithValue("@IdFam", row.Cells["IdFam"].Value);
                    	con.Open();
                        deleteNatures.ExecuteNonQuery();
                    	deleteFamilles.ExecuteNonQuery();
                    }
    
                    con.Close();
                }
            }
            catch (SystemException ex)
            {
                MessageBox.Show(string.Format("An error occurred: {0}", ex.Message));
            }
    
            //Update the datagridview
            this.BindGrid();
        }
    }
