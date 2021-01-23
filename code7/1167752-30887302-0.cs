    public IEnumerable ListTop10countries(string mydirection)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MYCON"].ToString()))
        {
             var list = con.Query<OutputCountries>("Usp_GetTop10", new {direction = mydirection}, commandType: CommandType.StoredProcedure).AsEnumerable();
             return list;
        }
    }
