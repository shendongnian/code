     private void button1_Click(object sender, EventArgs e)
     {
         string idcan = textBox3.Text;
         string score = textBox4.Text;
         Connection con = new Connection();
         SqlConnection sqlcon = con.Sambung();
         sqlcon.Open();
         string cek = "select count (ID_Candidate) as Score from DataVote where ID_Candidate = @idcan";
         using (sqlcon)
         {
             SqlCommand com = new SqlCommand(cek, sqlcon);
             com.Parameters.Add("idcan", SqlDbType.VarChar, 5).Value = score;
                 
         }
         try
         {
             sqlcon.Open();
             textBox4.Text=Convert.ToString(com.ExecuteScalar()); 
         }
         catch (Exception ex)
         {
             MessageBox.Show(ex.Message);
         }
     }
