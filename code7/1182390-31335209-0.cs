    private void btngno_Click(object sender, EventArgs e)
    {
        using (SqlConnection baglan = new SqlConnection("Server=.;Database=lalala;Trusted_Connection=true;"))
        {
            baglan.Open();
    
            using (SqlCommand cmd2 = new SqlCommand("UPDATE ilktablom SET gno = @gno Where Ad = @Ad AND Soyad= @Soyad AND Sifre = @Sifre", baglan))
            {
                cmd2.Parameters.Add("@gno", SqlDbType.Int).Value = gnotxt.Text;
                cmd2.Parameters.Add("@Ad", SqlDbType.Varchar).Value = txtAd.Text;
                cmd2.Parameters.Add("@Soyad", SqlDbType.Varchar).Value = txtSoyad.Text;
                cmd2.Parameters.Add("@Sifre", SqlDbType.Varchar).Value = txtSifre.Text;
                if (cmd2.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Process completed.");
                }
                else
                {
                    MessageBox.Show("Process not completed.");
                }
            }
        }
    }  
