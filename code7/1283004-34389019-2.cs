	public static partial class extensions
	{
		public static Dictionary<TKey, List<TElem>> Add<TKey, TElem>(this Dictionary<TKey, List<TElem>> dict, TKey key, TElem value)
		{
			List<TElem> list;
			if (dict.ContainsKey(key))
				list = dict[key];
			else
				dict[key] = list = new List<TElem>();
	
			list.Add(value);
			return dict;
		}
	}
