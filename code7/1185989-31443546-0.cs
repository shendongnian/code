    public DataTable Get_Employers_All_Day(DateTime Date_Day)
    {
        DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
        DAL.Open();
    
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Date_Day", SqlDbType.DateTime);
        param[0].Value = Date_Day;
        DataTable result;
        try
        {
            result = DAL.ExecuteCommand("Get_Employers_All_Day", param);
        }
        finally
        {
            // Even if ExecuteCommand() fails, close any open connections
            DAL.Close();
        }
        return result;
    }
