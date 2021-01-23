    public static void something()
    {
       string stmt = "select * from GazeTable where id = " + 1 + " ;";
       SqlConnection conn = GetConnection();
       SqlCommand cmd = new SqlCommand(stmt, conn);
    
       conn.Open();
       using (var reader = cmd.ExecuteReader())
       {
          while (reader.Read())
          {
             Console.WriteLine(reader.GetTimeSpan(3));
          }
       }
       conn.Close();
    }
