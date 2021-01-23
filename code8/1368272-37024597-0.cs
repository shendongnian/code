	public static async Task<IEnumerable<Product>> GetAllProduct()
	{
		using (var con = new SqlConnection(connectionString))
		{
			await con.OpenAsync();
			return await con.QueryAsync<Product>("spGetAllStudentDetails", commandType: CommandType.StoredProcedure);
		}
	}
