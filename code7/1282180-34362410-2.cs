    public static string GetPlatypusNameForlatypusId(string platypusId)
    {
        SqlConnection sqlConn = new SqlConnection(CPSConnStr);
        SqlCommand cmd = new SqlCommand();
        SqlParameter param = new SqlParameter();
    
        cmd.CommandText = "SELECT PNAME FROM DUCKBILLS WHERE PLATYPUSID = @PLATYPUSID";
        param.SqlDbType = SqlDbType.VarChar;
        param.ParameterName = "@PLATYPUSID";
        param.Value = platypusId;
        cmd.CommandType = CommandType.Text;
        cmd.Connection = sqlConn;
    
        sqlConn.Open();
    
        var platypusName = cmd.ExecuteScalar().ToString();
    
        sqlConn.Close();
        return platypusName;
    }
    labelPlatypusName.Text = GetPlatypusNameForPlatypusId("4F");
