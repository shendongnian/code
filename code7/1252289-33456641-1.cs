            ...
            var details = new List<Dictionary<string, object>>();
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        var dict = new Dictionary<string, object>();
                        for (int i = 0; i < rdr.FieldCount; i++)
                        {
                            dict.Add(rdr.GetName(i), rdr.IsDBNull(i) ? null : rdr.GetValue(i));
                        }
                        details.Add(dict);
                    }
                }
            }
            ...
