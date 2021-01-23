    public PlainBrgDataSummaryComplete SummaryComputationPerTransSQLite(long    ProgramID)
    {
    DataSet dataSet = GetPlainBrgDataSQLite(ProgramID);
    return dataSet.Tables["dataBridge"]
        .AsEnumerable()
        //.Where(a => Convert.ToDateTime(a["reportingDate"].ToString()) >= startOfWeek1 && Convert.ToDateTime(a["reportingDate"].ToString()) < endOfWeek1.AddDays(1))
       .GroupBy(a => 1)
        .Select(d =>
            new PlainBrgDataSummaryTrans
            {
                transactionWk6 = d.Sum(a => a.Field<double?>("TranCount"))
            }
        ).FirstOrDefault();
}
