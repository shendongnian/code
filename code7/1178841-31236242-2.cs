    public String[] Get_Drug(int id)
    {
        OracleConnection con = new OracleConnection();
    
        con.ConnectionString = "User Id=scott;Password=tiger;Data Source=XE";
        con.Open();
    
        OracleCommand oraCmd = new OracleCommand();
        oraCmd.Connection = con;
        oraCmd.BindByName = true;
        oraCmd.CommandType = CommandType.StoredProcedure;
        oraCmd.CommandText = "RETREIVE_DRUG";
    
        OracleParameter[] param = new OracleParameter[9];
    
        param[0] = new OracleParameter("drugId", OracleDbType.Decimal);
        param[0].Direction = ParameterDirection.Input;
        param[0].Value = id;
        param[1] = new OracleParameter("drugName", OracleDbType.Varchar2);
        param[1].Direction = ParameterDirection.Output;
        param[1].Size = 30;
        param[2] = new OracleParameter("prodDate", OracleDbType.Date);
        param[2].Direction = ParameterDirection.Output;
        param[3] = new OracleParameter("expireDate", OracleDbType.Date);
        param[3].Direction = ParameterDirection.Output;
        param[4] = new OracleParameter("price", OracleDbType.Decimal);
        param[4].Direction = ParameterDirection.Output;
        param[5] = new OracleParameter("description", OracleDbType.Varchar2);
        param[5].Size = 30;
        param[5].Direction = ParameterDirection.Output;
        param[6] = new OracleParameter("quantity", OracleDbType.Decimal);
        param[6].Direction = ParameterDirection.Output;
        param[7] = new OracleParameter("buying", OracleDbType.Decimal);
        param[7].Direction = ParameterDirection.Output;
        param[8] = new OracleParameter("company", OracleDbType.Varchar2);
        param[8].Size = 30;
        param[8].Direction = ParameterDirection.Output;
        oraCmd.Parameters.AddRange(param);
    
        oraCmd.ExecuteNonQuery();
        con.Close();
    
        String[] ret = new String[8];
        ret[0] = oraCmd.Parameters["drugName"].Value.ToString();
        ret[1] = oraCmd.Parameters["prodDate"].Value.ToString();
        ret[2] = oraCmd.Parameters["expireDate"].Value.ToString();
        ret[3] = oraCmd.Parameters["price"].Value.ToString();
        ret[4] = oraCmd.Parameters["description"].Value.ToString();
        ret[5] = oraCmd.Parameters["quantity"].Value.ToString();
        ret[6] = oraCmd.Parameters["buying"].Value.ToString();
        ret[7] = oraCmd.Parameters["company"].Value.ToString();
        return ret;
    }
    
