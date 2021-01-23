    string query = "select Id from Persons where Name = @Name";
    using (SqlCommand cmd = new SqlCommand(query, connection)) {
      cmd.Parameters.Add('@Name', SqlDbType.NVarChar, 50).value = name;
      using (SqlDataReader reader = cmd.ExecuteReader()) {
        while (reader.Read()) {
          ...
        }
      }
    }
