            comm.CommandText= "update User set Pass= '" + textBox2.Text + "' where Pass= '" + textBox1.Text + "' and id=" + Korisnik.ID + "";
            comm.Connection = konekcija;
    
            try
            {
                conn.Open();
                int noOfRecordsUpdated = comm.ExecuteNonQuery();
                if (noOfRecordsUpdated > 0) {
                   MessageBox.Show("Success yaaay!", "Info");
                } else {
                   MessageBox.Show("No dice", "Info");
                }
    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
