	bool IsEqual(IPropertyComparer o1, IPropertyComparer o2)
	{
		var props = typeof(IPropertyComparer).GetProperties();
	
		foreach(var prop in props)
		{
			var v1 = prop.GetValue(o1);
			var v2 = prop.GetValue(o2);
			
			if(v1 == null)
			{
				if(v2 != null) return false;
			}
			else
			{
				if(!v1.Equals(v2)) return false;
			}
		}
	
		return true;
	}
