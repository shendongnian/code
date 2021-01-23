	public IQueryable<ITest2> ApplyFilterOnQuery(IQueryable<ITest2> query, Parameter input)
	{
		switch(input.Type)
		{
			Case bool:
				var boolValue = Convert.ToBoolean(input.ObjectValue);
				query = query.Where(a=> a.Collection.Any(b => b.TestValue.C1 == input.Parameter1 && b.TestValue.C2 == input.Parameter && b.BoolValue == boolValue);
				break;
			Case dateTime :
				// convert to datetime and check
				var dateTimeValue = Convert.ToDateTime(input.ObjectValue);
				query = query.Where(a=> a.Collection.Any(b => b.TestValue.C1 == input.Parameter1 && b.TestValue.C2 == input.Parameter && b.DateTimeValue == dateTimeValue );
				break;
			Case int:
				// convert to int and check
				// ...
				break;
		}
	}
