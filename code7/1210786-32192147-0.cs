            // Store the output query
            StringBuilder query = new StringBuilder();
            // Insert query that adds the database name
            // and table name passed through
            query.Append("UPDATE ");
            query.Append(config.DatabaseName);
            query.Append(".dbo.");
            query.Append(typeof(T).Name);
            query.Append(" SET ");
            query.Append(columnName);
            query.Append(" = ");
            query.Append("@columnValue");
            query.Append(" WHERE ");
            query.Append(whereColumn);
            query.Append(" = ");
            query.Append("@whereValue");
            // Execute the update
            using (SqlConnection conn = DBConnection.GetSqlConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query.ToString(), conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@columnValue", columnValue));
                    cmd.Parameters.Add(new SqlParameter("@whereValue", whereValue));
                    cmd.ExecuteNonQuery();
                }
            }
        }
