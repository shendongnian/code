     SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["NewConnectionString"].ConnectionString);
    
     {
    con.Open();
                
      string DatabaseName = Application.StartupPath + @"\MyDb.mdf";
    
    SqlCommand cmd = new SqlCommand("BACKUP DATABASE ["+DatabaseName+"] to DISK='D:\\MyBackup.bak' ", con);
                
                
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Success");
                }
                catch (Exception Ex){
                    MessageBox.Show("'"+Ex.ToString()+"'");
                }
                con.Close();
                
    }
