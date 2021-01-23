    static DataTable GetDataFromDatabase()
    {
      DataTable dt = new DataTable() ;
      
      using ( SqlConnection conn = new SqlConnection( "Server=localhost;Database=sandbox;Trusted_Connection=True;" ) )
      using ( SqlCommand cmd = conn.CreateCommand() )
      using ( SqlDataAdapter sda = new SqlDataAdapter(cmd) )
      {
        
        cmd.CommandText = "select * from sys.objects" ;
        cmd.CommandType = CommandType.Text ;
        
        conn.Open() ;
        sda.Fill(dt) ;
        conn.Close() ;
      }
      
      return dt ;
    }
