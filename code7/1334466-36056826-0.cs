    private Task<DataSet> ExecuteSqlQueryAsync(string connectionString, string sqlQuery, Dictionary<string, object> parameters = null)
    {
        return Task.Factory.StartNew(
        () =>
        {
            try
            {
                connstring = System.Configuration.ConfigurationManager.AppSettings[connectionString].ToString();
                dbconn = new SqlConnection(connstring);
                cm = new SqlCommand(sqlQuery, dbconn);
                dbconn.Open();
                cm.CommandTimeout = 0;
                if (params != null) {
                    foreach(var pair in parameters)
                    {
                        cm.Parameters.AddWithValue(pair.Key, pair.Value);
                    }
                }
                
                datasetttt = new DataSet();
                da = new SqlDataAdapter(cm);
                da.Fill(datasetttt, "Data");
                return datasetttt;
            }
            catch (Exception exception) { throw exception; }
            finally
            {
                dbconn.Close();
                cm.Dispose();
                da.Dispose();
            }
        });
    }
