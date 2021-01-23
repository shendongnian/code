	public IEnumerable<Difference> GetDifferences(Customer oldOne, Customer newOne)
	{
		var props = typeof(Customer).GetProperties();
		
		foreach (var prop in props)
		{
			var oldvalue = prop.GetValue(oldOne);
			var newvalue = prop.GetValue(newOne);
			if(oldvalue != newvalue)
				yield return new Difference { CustomerNo = oldOne.CustomerNo, PropertyName = prop.Name, OldValue = oldvalue.ToString(), NewValue = newvalue.ToString() };
		}
	}
