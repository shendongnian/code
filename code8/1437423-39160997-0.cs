    var itemProperties = typeof(TItem).GetProperties();
	List<TDuplicate> tempDuplicateExpression = DuplicateExpression
		.Where(m => itemProperties.Any(olumn => column.Name == m.ExpressionName))
		.ToList();
		
	return tempDuplicateExpression;
