    public BoilerReading ExecuteQuery()
    {
        var MyBoilerReading = new BoilerReading();
        DataTable dt = new DataTable();
        SqlConnection connection = new SqlConnection("Data Source=.\\SQLExpress;Initial Catalog=DNN;User ID=sa;Password=*****;");
        connection.Open();
        SqlCommand sqlCmd = new SqlCommand("select top 1 * from DNN.dbo.avtActionForm_BoilerReadingsLog order by TimeStamp", connection);
        SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
        sqlDa.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            DateTime TimeStamp_q = (DateTime)dt.Rows[0]["TimeStamp"];
            int TurbineChosen_q = (int)dt.Rows[0]["TurbineChosen"];
            decimal MOPSuctionPressure_q = (decimal)dt.Rows[0]["MOPSuctionPressure"];
            decimal LubeOilPressure_q = (decimal)dt.Rows[0]["LubeOilPressure"];
            decimal ControlOilPressure_q = (decimal)dt.Rows[0]["ControlOilPressure"];
            .... etc.
            MyBoilerReading.Timestamp = TimeStamp_q;
            MyBoilerReading.TurbineChosen = TurbineChosen_q;
            ... etc.    
        }
        connection.Close();
        return MyBoilerReading; //return the instance that you actually populate with values.      
    }
