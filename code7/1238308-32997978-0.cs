    static class CollectionExtensions {
    	public static List<dynamic> ToDynamicList<T>(this ICollection<T> collection) {
    		var result = new List<dynamic>(collection.Count);
    		result.AddRange(collection.Cast<dynamic>());
    		return result;
    	}
    }
