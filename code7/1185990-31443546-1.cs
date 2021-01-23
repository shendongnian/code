    public DataTable Get_Employers_All_Day(DateTime Date_Day)
    {
        ...
        ...
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
