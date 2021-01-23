    private void importComandăToolStripMenuItem_Click(object sender, EventArgs e)
    {
       string connstring = @"server=localhost; 
                             Trusted_Connection=yes; 
                             database=erp; connection timeout=30";
       string cale = GetFileName();
       if(cale != string.Empty)
       {
          IEnumerable<string> arrLines = File.ReadLines(cale);
          string sql = @"Insert into [erp].[dbo].[Comenzi] values 
                                                @P1, @P2, @P3, @P4";
          using (SqlConnection conn = new SqlConnection(connstring))
          {
              conn.Open();
              using (SqlCommand cmd = new SqlCommand(sql, conn))
              {
                  cmd.Parameters.AddWithValue("@P1", 0);
                  cmd.Parameters.AddWithValue("@P2", 0);
                  cmd.Parameters.AddWithValue("@P3", DateTime.MinValue);
                  cmd.Parameters.AddWithValue("@P4", DateTime.MinValue);
                  
                  foreach (string sLine in arrLines)
                  {
                     string[] vcmd = sLine.Split(' ');
                     cmd.Parameters["@P1"].Value = Convert.ToInt32(vcmd[0]));
                     cmd.Parameters["@P2"].Value = Convert.ToInt32(vcmd[1]));
                     cmd.Parameters["@P3"].Value = Convert.ToDateTime(vcmd[2]));
                     cmd.Parameters["@P4"].Value = Convert.ToDateTime(vcmd[3]));
                     cmd.ExecuteNonQuery();
                  }
              }
           }
           //check can be added based on int returned by ExecuteNonQuery
           MessageBox.Show("Comanda inserată");
        }                
    }
    //method to show open file dialog return filename or empty
    private string GetFileName()
    {
        OpenFileDialog ofd = new OpenFileDialog();
        if (ofd.ShowDialog() == DialogResult.OK)
             return ofd.FileName;
        else
        {
             MessageBox.Show("Inserare eșuată");
             return string.Empty;
         }
    }
     
