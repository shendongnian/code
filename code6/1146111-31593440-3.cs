    <!-- language: c# -->
        SqlConnection _Connection = new sqlConnection(_ConnectionStringFromSomewhere);
        SqlCommand _Command = _Connection.CreateCommand();
        SqlDataReader _Reader = null;
        try
        {
          _Connection.Open();
          // SET command needs to be in its own batch
          _Command.CommandText = "SET something ON";
          _Command.ExecuteNonQuery();
          // Now we can run the desired query
          _Command.CommandText = _QueryToTest;
          _Reader = _Command.ExecuteReader();
          ..get you some execution plans!
        }
        finally
        {
          if (_Reader != null)
          {
            _Reader.Dispose();
          }
          _Command.Dispose();
          _Connection.Dispose();
        }
