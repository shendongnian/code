    String _sFirstNameQuery = "";
    string sql = "SELECT Firstname FROM EnrollmentDB WHERE SessionID Like 'cc7b87e4c1074d93bfad451ae10eb3b0'";
    using (conn)
    {
       SqlCommand cmd = new SqlCommand(sql, conn);
       try
       {
          conn.Open();
          _sFirstNameQuery = (String)cmd.ExecuteScalar();
       }
       catch (Exception ex)
       {
          Console.WriteLine(ex.Message);
       }
