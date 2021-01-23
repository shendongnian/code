    using (SqlConnection conn = new SqlConnection(DatabaseConnectionString))
    using (SqlCommand cmd = conn.CreateCommand())
    {
        var @params = new Dictionary<string, object>{
            { "something", myValue },
            { "somethingDifferent", anotherValue },
        };
        cmd.CommandText = "SELECT something, somethingAgain " + 
                  "FROM aDBTable " +
                  "WHERE something = @something'" +
                  "AND something <> @somethingDifferent'";
        foreach (KeyValuePair<string, object> item in values)
        {
            cmd.Parameters.AddWithValue("@" + item.Key, item.Value);
        }
    
        DataTable table = new DataTable();
        using (var reader = cmd.ExecuteReader())
            {
                table.Load(reader);
                return table;
            }
        }
    }
