     try
        {
        DialogResult answer;
                    answer = MessageBox.Show("Are you sure you want to delete this record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        
                    if (answer == DialogResult.Yes)
                    {
                        con.Open();
                        com.CommandText = "DELETE FROM tblsupply WHERE (prnumber=@prnumber AND description=@description)";
                        com.Parameters.Clear();
                        com.Parameters.AddWithValue("@prnumber", txtprn.Text);
                        com.Parameters.AddWithValue("@description", txtdescription.Text);
                        com.ExecuteNonQuery();
                        MessageBox.Show("Record Deleted!");
                        con.Close();
                    }
                    ClearFields();
                    GridRefresh();
        }
        catch(Exception ex)
        {
          ex.Message.ToString();
        }
