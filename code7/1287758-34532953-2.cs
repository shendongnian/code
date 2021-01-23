    public <class name>() : base(ConnectionStrings["MSSQL_DBConnectionString"].ToString(), "")
    {
       ///*'StoredProcedure USE*/
    	this.SelectCommandType = SqlDataSourceCommandType.StoredProcedure;
    	this.InsertCommandType = SqlDataSourceCommandType.StoredProcedure;
    	this.DeleteCommandType = SqlDataSourceCommandType.StoredProcedure;
    	this.UpdateCommandType = SqlDataSourceCommandType.StoredProcedure;
    }
