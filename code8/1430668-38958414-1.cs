    interface ICollectionBuilder
	{
		object Build(IList dictionaries);
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
                //you don't have to cast the object here, PropertyInfo.SetValue will accept it "as is":
				object newVal = curr.Value;				
				IDictionary<string, object> curDict = curr.Value as IDictionary<string, object>;
				IList curList = curr.Value as IList;
				if (curDict != null && newType.GetConstructor(Type.EmptyTypes) != null)
				{
					newVal = ((IDictionaryConverter)Activator.CreateInstance(typeof(DictionaryConerter<>).MakeGenericType(newType))).Convert(curDict);
				}
				else if (
					curList != null &&
					curList.OfType<IDictionary<string,object>>().Any() &&
					newType.IsGenericType &&
					newType.GetGenericTypeDefinition() == typeof(List<>) &&
					newType.GetGenericArguments()[0].GetConstructor(Type.EmptyTypes) != null)
				{
					newVal = ((ICollectionBuilder)Activator.CreateInstance(typeof(CollectionBuilder<>).MakeGenericType(newType.GetGenericArguments()[0]))).Build(curList);
				}
				
				t.GetType().GetProperty(currProperty.Name).SetValue(t, newVal);
			}
			return t;
		}
	}
	class CollectionBuilder<T> : ICollectionBuilder where T : new()
	{
		public object Build(IList dictionaries)
		{
			DictionaryConerter<T> dictConverter = new DictionaryConerter<T>();
			List<T> list = dictionaries
				.OfType<IDictionary<string,object>>()
				.Select(dict => dictConverter.ConvertTyped(dict))
				.ToList();
			
			return list;
		}
	}
