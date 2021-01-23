     namespace TrendsTwitterati 
     {
     	public partial class Default: System.Web.UI.Page
     	{
    
     	}
    
     	public static class MyExtensions 
     	{
     		public static IEnumerable < TSource > DistinctBy < TSource, TKey > (this IEnumerable < TSource > source, Func < TSource, TKey > keySelector) 
     		{
     			HashSet < TKey > seenKeys = new HashSet < TKey > ();
     			foreach(TSource element in source) 
     			{
     				if (seenKeys.Add(keySelector(element)))
     				{
     					yield
     					return element;
     				}
     			}
     		}
     	}
     }
