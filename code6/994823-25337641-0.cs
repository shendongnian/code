    public static void SaveClientHistory(String strMessage, String strClientIP)
    {
        SqlConnection objSqlConn = new SqlConnection(strConnectionString);
        SqlCommand objSqlCmd = new SqlCommand("procInsertHistory", objSqlConn)
        objSqlCmd.CommandType = CommandType.StoredProcedure;
        objSqlCmd.Parameters.AddWithValue("@strMessage", strMessage);
        objSqlCmd.Parameters.AddWithValue("@strClientIP", strClientIP);
        try{
            objSqlConn.Open();
            objSqlCmd.ExecuteNonQuery();               
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
        finally
        { 
            if(objSqlConn.State == ConnectionState.Open)
                objSqlConn.Close();
        }
    }
