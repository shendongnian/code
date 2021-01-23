    public override bool Delete(int primaryKey)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Id", primaryKey, DbType.Int32);
			parameters.Add("@b", dbType: DbType.Int32, direction: ParameterDirection.Output);
			parameters.Add("@c", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
            Connection.Execute("Language_Delete",
                parameters, commandType: CommandType.StoredProcedure);
				
		    int b = parameters.Get<int>("@b");
			// Output
			int c = parameters.Get<int>("@c");
			// ReturnValue
            
			
        }
