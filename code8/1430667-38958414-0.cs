	interface ICast
	{
		object Apply(object onSource);
	}
	class Cast<TCast> : ICast
	{
		public object Apply(object onSource)
		{
			return (TCast)onSource;
		}
	}
	interface IDictionaryConverter
	{
		object Convert(IDictionary<string, object> dict);
	}
	class DictionaryConerter<T> : IDictionaryConverter where T : new()
	{
		public object Convert(IDictionary<string, object> dict)
		{
			return ConvertTyped(dict);
		}
		
		public T ConvertTyped(IDictionary<string, object> dict)
		{
			T t = new T();
			PropertyInfo[] properties = t.GetType().GetProperties();
			foreach (KeyValuePair<string, object> curr in dict)
			{
				if (String.IsNullOrEmpty(curr.Key)) continue;
				if (curr.Value == null) continue;
				Type valType = null;
				Type newType = null;
				PropertyInfo currProperty = null;
				foreach (PropertyInfo p in properties)
				{
					if (String.IsNullOrEmpty(p.Name)) continue;
					if (String.Compare(p.Name.ToLower(), curr.Key.ToLower()) == 0)
					{
						valType = t.GetType().GetProperty(p.Name).PropertyType;
						newType = Nullable.GetUnderlyingType(valType) ?? valType;
						currProperty = p;
						break;
					}
				}
				//			object newVal = Convert.ChangeType(curr.Value, newType);
				object newVal;
				IDictionary<string,object> curDict = curr.Value as IDictionary<string, object>;
				if (curDict != null && newType.GetConstructor(Type.EmptyTypes) != null)
				{
					newVal = ((IDictionaryConverter)Activator.CreateInstance(typeof(DictionaryConerter<>).MakeGenericType(newType))).Convert(curDict);
				}
				//process the case of collection here:
				//else if (...)
				//{
				//
				//}
				else
				{
					newVal = ((ICast)Activator.CreateInstance(typeof(Cast<>).MakeGenericType(newType))).Apply(curr.Value);
				}
				t.GetType().GetProperty(currProperty.Name).SetValue(t, newVal);
			}
			return t;
		}
	}
