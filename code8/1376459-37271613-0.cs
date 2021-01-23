             public string Save(string SpName)
                    {
        SqlConnection Conn = OpenConnection();  // connection open function you create this funciton
        String rv = string.Empty;
        try
        {
            Comm.Connection = Conn;
            Comm.CommandText = SpName;
            Comm.CommandType = CommandType.StoredProcedure;
            Comm.ExecuteNonQuery();
            rv = ("Successfully Saved.");
        }
        catch (Exception ex)
        {
            rv = ("Fails :" + ex.ToString());
        }
        finally
        {
            if (Conn.State != ConnectionState.Closed)
                Conn.Close();
        }
        return rv;
        }
