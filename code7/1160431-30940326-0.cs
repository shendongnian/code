public IEnumerable<T> ExecuteReaderToList<T>(string storedProcedure, IDictionary<string, object> parameters = null,
              string connectionString = null)
        {
            ICollection<T> list = new List<T>();
            var properties = typeof(T).GetProperties();           
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = storedProcedure;
                cmd.CommandType = CommandType.StoredProcedure;
                if (parameters != null)
                {
                    foreach (KeyValuePair<string, object> parameter in parameters)
                    {
                        cmd.Parameters.AddWithValue(parameter.Key, parameter.Value);
                    }
                }
                cmd.Connection = conn;
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var element = Activator.CreateInstance<T>();
                        foreach (var f in properties)
                        {
                            var o = reader[f.Name];
                            if (o.GetType() != typeof(DBNull))
                            {
                                f.SetValue(element, o, null);
                            }
                            o = null;
                        }
                        list.Add(element);
                    }
                }
                conn.Close();
            }
            return list;
        }
