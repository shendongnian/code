	public static class Extensions
	{
		public static List<List<T>> RemoveDuplicates<T>(this List<List<T>> items, T replacedValue) where T: class
		{
			List<List<T>> ret = items;
			
			ret.ForEach(m=> {
				var ind = items.IndexOf(m);
				var prevItem = ind==0? null : items.Skip(items.IndexOf(m)-1).FirstOrDefault();
				
				if (prevItem == null) return;
				for(var a = 0; a < prevItem.Count; a++)
					if(prevItem[a] == m[a]) m[a] = replacedValue;
			});
			
			return ret;
		}
	}
