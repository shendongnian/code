	var propInfo = (PropertyInfo)member.Member;
	var constantValue = Expression.Constant(filter.Value, propInfo.PropertyType);
	var typeCode = Type.GetTypeCode(propInfo.PropertyType);
	var property = Expression.Property(param, propInfo);
	switch (filter.Operation)
	{
		case Enums.Op.Equals:
			return Expression.Equal(property, constantValue);
		case Enums.Op.NotEqual:
			return Expression.NotEqual(property, constantValue);
		case Enums.Op.GreaterThan:
			return Expression.GreaterThan(property, constantValue);
	}
