    public List<MModel> GetReportData(DateTime startDateTime, DateTime endDateTime, bool onlineFiling)
    {
        var managementModel = new List<ManagementModel>();
        var oracCmd = new OracCommand(1);
        oracCmd.AddInParameter(OracleDbType.Date, "I_STARTDATE", startDateTime));
        oracCmd.AddInParameter(OracleDbType.Date, "I_ENDDATE", endDateTime));
        oracCmd.AddInParameter(OracleDbType.BinaryDouble, "I_ONLINE", onlineFiling));
        //rest of code here
