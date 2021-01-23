    partial class TreeHelper
    {
    	public static IEnumerable<CustomObject> Expand(this IEnumerable<CustomObject> source)
    	{
    		return source.Expand(item => item.CustomObjects != null && item.CustomObjects.Count > 0 ? item.CustomObjects : null);
    	}
    }
