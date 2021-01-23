    using(var command = new MySqlConnection(connectionString))
    {
     command.CommandText = sql;
     try
      {
        using(SqlDataReader reader = command.ExecuteReader())
        {
          while (reader.Read())
                {
                    var t = new T();
                    var i = 0;
                    foreach (var property in properties)
                    {
                        try
                        {
                            property.SetValue(t, reader.GetValue(i++));
                        }
                        catch (Exception ex)
                        {
                            HandleSetValueException<T>(sql, parameters, reader, connection, ex);
                        }
                    }
                    yield return t;
                }
           }
        }
        catch (Exception ex)
        {
           throw new MoranbernateQueryException(sql, ex);
        }
    }
