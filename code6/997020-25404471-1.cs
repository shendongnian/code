    public static T ExecuteProcedureReturnDataTable<T>(string procedureName, SqlParameter[] prmArray = null) where T : DataTable, new()
    {
        T dt = new T();
        using (SqlConnection connection = new SqlConnection(Common.GetConnectionString()))
        {
            SqlCommand command = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter(command);
            try
            {
                // attempt to open sql connection and exec command
                connection.Open();
                command.Connection = connection;
                command.CommandText = procedureName;
                command.CommandType = CommandType.StoredProcedure;
                // add parameters to command if they exist
                if (prmArray != null)
                {
                    foreach (SqlParameter p in prmArray)
                    {
                        command.Parameters.AddWithValue(p.ParameterName, p.Value);
                    }
                }
                da.Fill(dt);
            }
            catch (SqlException exSql)
            {
                EventLogging.LogEvent("Exception", exSql.ToString());
                dt = null;
            }
            catch (Exception ex)
            {
                EventLogging.LogEvent("Exception", ex.ToString());
                dt = null;
            }
            finally
            {
                command.Dispose();
                connection.Dispose();
            }
        }
        return dt;
    }
