    private static DateTime getHireDate(string Database, string employeename)
    {
      SqlConnection connection = new SqlConnection(Database);
      SqlCommand command = new SqlCommand("_uspGetHireDate", connection);
      command.CommandType = CommandType.StoredProcedure;
    
      connection.Open();
      var result = Convert.ToDateTime(command.ExecuteScalar());
      connection.Close();
    
      return result;
    }
