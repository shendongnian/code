    public int AddPerson(Person person)
    {
      using (var connection = new SQLiteConnection(dbFile))
      {
        connection.Open();
        using (var command = new SQLiteCommand("spAddPerson",connection))
        {
          command.CommandType = CommandType.StoredProcedure;
          var idParameter = new SQLiteParameter("@Id", DbType.Int32);
          idParameter.Direction = ParameterDirection.Output;
          command.Parameters.Add(idParameter);
          command.Parameters.AddWithValue("@FirstName", person.FirstName);
          command.Parameters.AddWithValue("@LirstName", person.LastName);
          command.ExecuteNonQuery();
        }
      }
      return person.Id;
    }
