    string cs = "Data Source=IS020114\\CODRINMA;Initial Catalog=gcOnesti;Integrated Security=True";
    
    private void conectareToolStripMenuItem_Click(object sender, EventArgs e)
    {
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    MessageBox.Show("Connection successful !!");    
                }
            }
            catch (Exception er) {
                MessageBox.Show("Connection unsuccessful..");
            }
    
    }
