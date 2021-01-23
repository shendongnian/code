      if (string.IsNullOrEmpty(string))
            {
                sqlQuery.Parameters.Add("@string", SqlDbType.VarChar, 50).Value = DBNull.Value;
            }
            else
            {
                sqlQuery.Parameters.Add("@string", SqlDbType.VarChar, 50).Value = string;
            }
