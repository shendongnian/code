	public static void Localize(object o, string cultureInfo)
	{
		if (o != null)
		{
			foreach (var property in o.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
			{
				if (property.CustomAttributes.FirstOrDefault(ca => ca.AttributeType == typeof(LocalizableAttribute)) != null)
				{
					property.SetValue(o, GetLocalizedText(property.GetValue(o, null).ToString(), cultureInfo), null);
				}
				else
				{
					var value = property.GetValue(o);
					if (value != null) 
					{
						if (property.PropertyType.IsArray || (property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(List<>)))
						{
							foreach (var el in (IEnumerable)value)
							{
								Localize(el, cultureInfo);
							}
						}
						else
						{
							Localize(value, cultureInfo);
						} 
					}
				}
			}
		}
	}
