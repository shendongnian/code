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
                  foreach (string sLine in arrLines)
                  {
                     string[] vcmd = sLine.Split(' ');
                            
                     if(vcmd.Length >= 4) //condition for check exact 
                        for (int i = 1; i <= 4; i++)                            
                           cmd.Parameters.AddWithValue("@P" + i, vcmd[i - 1]); 
                            
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
     
