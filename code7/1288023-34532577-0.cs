    	public class Helper
		{
			public void InitializeDropdownItemLists<T>(T model)
			{
				var props = typeof (T).GetProperties();
				foreach (var p in props)
				{
					var type = p.PropertyType;
					if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof (List<>))
					{
						var itemType = type.GetGenericArguments()[0];
						if (itemType == typeof (DropdownItem))
						{
							p.SetValue(model, new List<DropdownItem>());
						}
					}
				}
			}
		}
