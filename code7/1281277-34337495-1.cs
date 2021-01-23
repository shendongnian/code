    public DataSet GetAlphaDawg(int employeeid, DateTime hiredate, DateTime terminationdate)
    {
        DataSet dsAlpha = new DataSet();
        try
        {
            System.Configuration.ConnectionStringSettings connstring = System.Configuration.ConfigurationManager.ConnectionStrings["SQLServer1"];
            using (var conn = new SqlConnection(connstring.ConnectionString))
            {
                using (var da = new SqlDataAdapter("alphadawg", conn))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    var parameter = da.SelectCommand.Parameters;
                    parameter.Add("@employeeid", SqlDbType.Int).Value = employeeid;
                    parameter.Add("@hiredate", SqlDbType.Date).Value = hiredate;
                    parameter.Add("@terminationdate", SqlDbType.Date).Value = terminationdate;
                    da.Fill(dsAlpha); // Open/Close not needed with Fill
                    return dsAlpha;
                }
            }
        } catch (Exception) { throw; }
    }
