	// C# Code
	public bool CheckUsableID(int id, List<object> list)
	{
		foreach (var obj in list)
		{
			var objId = (int)GetValueFromObj(obj, "id");
			if (objId == id)
			{
				return false;
			}
		}
		return true;
	}
	private object GetValueFromObj(object obj, string propertyName)
	{
		return obj.GetType().GetProperty(propertyName).GetValue(obj);
	}
