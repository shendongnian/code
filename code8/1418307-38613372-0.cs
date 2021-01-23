    public static DataTable search(int? Year, string Name, string ID)
    {
        try
        {
            using (var cmd = new OracleCommand("SPROC_ONLINE", getConnectionString()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                var da = new OracleDataAdapter(cmd);
                cmd.Parameters.Add("Year", OracleDbType.Int32).Value = Year;
                cmd.Parameters.Add("Name", OracleDbType.Varchar2).Value = Name;
                cmd.Parameters.Add("ID", OracleDbType.Varchar2).Value = ID;
                cmd.Parameters.Add("Output", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        catch (Exception e) {throw new Exception("Error: " + e); }
        finally {}
    }
