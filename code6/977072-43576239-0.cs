    private Expression<Func<Goods, bool>> LambdaConstructor (string propertyName, string inputText, Condition condition)
		{
			
				var item = Expression.Parameter(typeof(Goods), "item");
				var prop = Expression.Property(item, propertyName);
				var propertyInfo = typeof(Goods).GetProperty(propertyName);
				var value = Expression.Constant(Convert.ChangeType(inputText, propertyInfo.PropertyType));
				BinaryExpression equal;
				switch (condition)
				{
					case Condition.eq:
						equal = Expression.Equal(prop, value);
						break;
					case Condition.gt:
						equal = Expression.GreaterThan(prop, value);
						break;
					case Condition.gte:
						equal = Expression.GreaterThanOrEqual(prop, value);
						break;
					case Condition.lt:
						equal = Expression.LessThan(prop, value);
						break;
					case Condition.lte:
						equal = Expression.LessThanOrEqual(prop, value);
						break;
					default:
						equal = Expression.Equal(prop, value);
						break;
				}
				var lambda = Expression.Lambda<Func<Goods, bool>>(equal, item);
				return lambda;
			}
