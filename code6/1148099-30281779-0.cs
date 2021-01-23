    var param = new SqlParameter();
    param.DbType = SqlDbType.Structured;
    param.ParameterName = "@Transaction";
    param.SqlValue = table; // Datatable or one of the acceptable SqlClient types above
    ctx.Query<List<TransactionModel>>(";exec sp_SaveTransactions  @0", param);
