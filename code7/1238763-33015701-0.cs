    public CacheElement FindElementByKey(Guid key)
    {
      using (var command = _connection.CreateCommand())
      {
        command.CommandType = CommandType.TableDirect;
        command.CommandText = "CacheElement";
        command.IndexName = "PK_CacheElement";
        using (var reader = command.ExecuteReader())
        {
            reader.Seek(DbSeekOptions.FirstEqual, key);
            if (reader.Read())
            {
                var element = new CacheElement();
                element.Key = key;
                element.Tag = reader.GetValue(1) == DBNull.Value ? null : reader.GetString(1);
                element.Value = (byte[])reader.GetValue(2);
                element.CreatedAt = reader.GetDateTime(3);
                element.ExpirationAt = reader.GetDateTime(4);
                return element;
            }
        }
        return null;
      }
    }
