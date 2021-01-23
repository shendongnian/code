    public object RunSQL(string sql)
    {
        SqlConnection Con1 = new SqlConnection("Data Source=.;database=daneshgah;integrated security=true");
        Con1.Open();
        SqlCommand command = new SqlCommand(strsql, Con1);
        return command.ExecuteScalar();
    }
    //In some event handler
    int myValue = RunSQL("Select Value from Table where ID = " + ID);
