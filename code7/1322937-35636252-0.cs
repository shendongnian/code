		public object GetValue(string readerValue, Type conversionType)
		{
			// if the type is a string, just return the value with no conversion
			if (conversionType == typeof(string) || conversionType == typeof(object))
			{
				return readerValue;
			}
			// if the field has a value try to cast it
			if (!string.IsNullOrWhiteSpace(readerValue))
			{
				readerValue = readerValue.Trim();
				if (conversionType.IsEnum)
				{
					return Enum.Parse(conversionType, readerValue);
				}
				else
				{
					Type underlyingType = Nullable.GetUnderlyingType(conversionType) ?? conversionType;
					if (underlyingType == typeof(int))
					{
						return int.Parse(readerValue);
					}
					else if (underlyingType == typeof(bool))
					{
						return bool.Parse(readerValue);
					}
					else if (underlyingType == typeof(DateTime))
					{
						return DateTime.Parse(readerValue);
					}
					else if (underlyingType == typeof(double))
					{
						return double.Parse(readerValue);
					}
					else if (underlyingType == typeof(long))
					{
						return long.Parse(readerValue);
					}
					else if (underlyingType == typeof(Guid))
					{
						return Guid.Parse(readerValue);
					}
					else if (underlyingType == typeof(long))
					{
						return long.Parse(readerValue);
					}
					else
					{
						// GetConverter and ConvertFrom are both slow, so only use it in a fallback
						TypeConverter converter = TypeDescriptor.GetConverter(underlyingType);
						return converter.ConvertFrom(readerValue);
					}
				}
			}
			// return null for nullable generic primitives
			else if (conversionType.IsGenericType && conversionType.GetGenericTypeDefinition() == typeof(Nullable<>))
			{
				return null;
			}
			// return the default value for non nullable primitive types
			else if (conversionType.IsValueType)
			{
				return Activator.CreateInstance(conversionType);
			}
			// return null for reference types
			else
			{
				return null;
			}
		}
