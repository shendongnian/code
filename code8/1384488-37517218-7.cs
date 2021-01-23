        private static MethodInfo GetUserDefinedBinaryOperator(ExpressionType binaryType, Type leftType, Type rightType, string name)
		{
			Type[] types = new Type[]
			{
				leftType,
				rightType
			};
			Type nonNullableType = leftType.GetNonNullableType();
			Type nonNullableType2 = rightType.GetNonNullableType();
			BindingFlags bindingAttr = BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
			MethodInfo methodInfo = nonNullableType.GetMethodValidated(name, bindingAttr, null, types, null);
			if (methodInfo == null && !TypeUtils.AreEquivalent(leftType, rightType))
			{
				methodInfo = nonNullableType2.GetMethodValidated(name, bindingAttr, null, types, null);
			}
			if (Expression.IsLiftingConditionalLogicalOperator(leftType, rightType, methodInfo, binaryType))
			{
				methodInfo = Expression.GetUserDefinedBinaryOperator(binaryType, nonNullableType, nonNullableType2, name);
			}
			return methodInfo;
		}
