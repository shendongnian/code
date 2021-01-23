    public void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext) 
    { 
        for (int i = 0; i < command.Parameters.Count; i++) {
				var param = command.Parameters[i];
				if (param.DbType == DbType.DateTime) {
					// Change param.Value here
				}
			}
    } 
