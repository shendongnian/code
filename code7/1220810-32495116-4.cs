	public static List<List<T>> RemoveDuplicates<T>(this List<List<T>> items, T replacedValue) where T: class
	{
		List<List<T>> ret = items;
		
		items.ForEach(m=> {
			var ind = items.IndexOf(m);
			
			if(ind==0)
			{
				ret.Add(items.FirstOrDefault());
			}
			else
			{
				var prevItem = items.Skip(items.IndexOf(m)-1).FirstOrDefault();
				
				var item = new List<T>();
				for(var a = 0; a < prevItem.Count; a++)
				{
					item.Add(prevItem[a] == m[a]? replacedValue : m[a]);
				}
				
				ret.Add(item);
			}
		});
		
		return ret;
    }
