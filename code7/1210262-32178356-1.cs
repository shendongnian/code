    public static string DataConnectExecuteNonQuery(CommandType CmdType, string CmdText, string SqlOutputParameterName = "Msg")
    {
        SqlCommand CmdExec = new SqlCommand();
        CmdExec.Connection = DataConnectionOpen();
        CmdExec.CommandType = CmdType;
        CmdExec.CommandText = CmdText;
        CmdExec.Parameters.Add("@" + SqlOutputParameterName, SqlDbType.VarChar).Direction = ParameterDirection.Output; //** HERE **//
        string msg;
        try
        {
             CmdExec.ExecuteNonQuery();
             msg = CmdExec.Parameters["@" + SqlOutputParameterName].Value.ToString();
        }
    }
