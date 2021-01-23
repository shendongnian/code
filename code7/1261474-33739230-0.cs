	bool IsEqual(IPropertyComparer o1, IPropertyComparer o2)
	{
		var props = typeof(IPropertyComparer).GetProperties();
		
		foreach(var prop in props)
		{
			if(!prop.GetValue(o1).Equals(prop.GetValue(o2))) return false;
		}
		
		return true;
	}
