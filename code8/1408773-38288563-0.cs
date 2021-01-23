	private IList<object> UpdateList(KeyValuePair<string, string> conditions)
	{
		var rawList = (IEnumerable)propertyListInfoToUpdate.GetValue(model);
		
		var listItemType = propertyListInfoToUpdate.GetGenericArguments().First();
		var filterMethod = this.GetType().GetMethod("Filter").MakeGenericMethod(genericType);
		
		object listToModify = rawList;
		foreach (var condition in conditions)
		{
			listToModify = filterMethod.Invoke(null, new object[] { listToModify, condition.Key, condition.Value })
		}
		return ((IEnumerable)listToModify).Cast<object>().ToList();
	}
