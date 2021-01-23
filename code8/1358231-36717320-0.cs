    private bool ParseContainsExpression(MethodCallExpression expression)
    {
    	// The method must be called Contains and must return bool
    	if (expression.Method.Name != "Contains" || expression.Method.ReturnType != typeof(bool)) return false;
    	var list = expression.Object;
    	Expression operand;
    	if (list == null)
    	{
    		// Static method
    		// Must be Enumerable.Contains(source, item)
    		if (expression.Method.DeclaringType != typeof(Enumerable) || expression.Arguments.Count != 2) return false;
    		list = expression.Arguments[0];
    		operand = expression.Arguments[1];
    	}
    	else
    	{
    		// Instance method
    		// Exclude string.Contains
    		if (list.Type == typeof(string)) return false;
    		// Must have a single argument
    		if (expression.Arguments.Count != 1) return false;
    		operand = expression.Arguments[0];
    		// The list must be IEnumerable<operand.Type>
    		if (!typeof(IEnumerable<>).MakeGenericType(operand.Type).IsAssignableFrom(list.Type)) return false;
    	}
    	// Try getting the list items
    	object listValue;
    	if (list.NodeType == ExpressionType.Constant)
    		// from constant value
    		listValue = ((ConstantExpression)list).Value;
    	else
    	{
    		// from constant value property/field
    		var listMember = list as MemberExpression;
    		if (listMember == null) return false;
    		var listOwner = listMember.Expression as ConstantExpression;
    		if (listOwner == null) return false;
    		var listProperty = listMember.Member as PropertyInfo;
    		listValue = listProperty != null ? listProperty.GetValue(listOwner.Value) : ((FieldInfo)listMember.Member).GetValue(listOwner.Value);
    	}
    	var listItems = listValue as System.Collections.IEnumerable;
    	if (listItems == null) return false;
    
    	// Do whatever you like with listItems
    
    	return true;
    }
