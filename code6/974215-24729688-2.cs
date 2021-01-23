    public IEnumerable<dcTransaction> SelectMasterTransaction(DateTime date1, DateTime date2)
    {
        string conString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        using (con = new SqlConnection(conString))
        using(SqlCommand cmd = new SqlCommand("spViewMasterTransaction", con))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter parameterDate1 = new SqlParameter();
            parameterDate1.ParameterName = "@date1";
            parameterDate1.Value = date1;
            cmd.Parameters.Add(parameterDate1);
            SqlParameter parameterDate2 = new SqlParameter();
            parameterDate2.ParameterName = "@date2";
            parameterDate2.Value = date2;
            cmd.Parameters.Add(parameterDate2);
            con.Open();
            using (SqlDataReader dtReader = cmd.ExecuteReader())
            {
                while (dtReader.HasRows)
                {
                    dcTransaction dcTrans = new dcTransaction();
        
                    dcTrans.no_trans = dtReader.GetInt32(0); // Index for "no_trans"
                    dcTrans.name = dtReader.GetString(1); // Index for "name"
                    dcTrans.sum = dtReader.GetInt32(2); // Index for "sum"
                    dcTrans.dates = dtReader.GetDateTime(3); // Index for "dates"
                    yield return dcTrans;
                    dtReader.NextResult();
                }
            }
        }
    }
