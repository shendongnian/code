    private void btnLogin_Click(object sender, EventArgs e) 
    { 
         var connectionString =   
    ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString; 
         using(MySqlConnection conn = new MySqlConnection(connectionString)) 
         using(MySqlCommand cmd = new conn.CreateCommand())
         {
              conn.open(); 
              cmd.CommandText = "Verify_Login"; 
              cmd.CommandType = CommandType.StoredProcedure; 
              .....
              cmd.ExecuteNonQuery(); 
              int valid = (int)(cmd.Parameters["@result"].Value); 
         } 
    } 
    
    
        
