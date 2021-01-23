    if (destType.IsValueType && (!destType.IsGenericType || !(destType.GetGenericTypeDefinition() == typeof(Nullable<>))))
    		{
    			throw new ArgumentException(Environment.GetResourceString("Argument_ConstantNull"));
    		}
    		TypeBuilder.SetConstantValue(module.GetNativeHandle(), tk, 18, null);
