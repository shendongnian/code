        // Usage
        .AsEnumerable().Select(s => db.uspTranscripts(s));
        // Stored Procedure
        [Function(Name="dbo.CustOrderTotal")] //probably dbo.uspTranscripts in your case
        [return: Parameter(DbType="Int")]
        public int CustOrderTotal([Parameter(Name="CustomerID", DbType="NChar(5)")] string customerID, [Parameter(Name="TotalSales", DbType="Money")] ref System.Nullable<decimal> totalSales)
        {
        	IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), customerID, totalSales);
            totalSales = ((System.Nullable<decimal>)(result.GetParameterValue(1)));
	        return ((int)(result.ReturnValue));
        }
