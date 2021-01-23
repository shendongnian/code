    public IDataWrapper GetNonPagedQuery<T>(string myQuery, object param, Action<T> customAction)
	{
		var obj = new DataWrapper();
		using (var oConn = CreateConnection(ConnectionString))
		{
			var results = oConn
				.Query<T>(myQuery)
				.ToList();
			obj.TotalRows = results.Count();
			obj.RowsFound = results
				.Select(value =>
				{
					customAction(value);
					return value;
				})
				.Cast<dynamic>();
		}
		return obj;
	}
