    private void btn_PRdel_Click_1(object sender, EventArgs e)
        {
            //Update button update dataset after insertion,upadtion or deletion
            DialogResult dr = MessageBox.Show("Are you sure to save Changes", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dr == DialogResult.Yes)
            {
                if (ID != 0)// where is the id value?
                {
                    cmd = new SqlCommand("DELETE FROM tbl_payrates WHERE ID=@id", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@id", ID);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record Deleted Successfully!");
                    PayratesDisplay();
                    ClearData();
                }
                else
                {
                    MessageBox.Show("Please Select Record to Delete");
                }
            }
        }
