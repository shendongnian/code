    short status;
    using (var sqlConnection = new SqlConnection(connectionString))
    {
      var parameters = new DynamicParameters();
      parameters.Add("@ID", ID, DbType.Int32, ParameterDirection.Input);
     await sqlConnection.OpenAsync();
     status = await sqlConnection.QueryAsync<short>("SELECT [StatusID] FROM [MyTable] WHERE [ID] = @ID", parameters, commandTimeout: _sqlCommandTimeoutInSeconds).Single();
    }
