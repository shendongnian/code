    public class ChartItemData
    	{
    		public double Average { get; set; }
    		public double HighScore { get; set; }
    		public double LowScore { get; set; }
    
    		public string Name { get; set; }
    	}
    
    	class Program
    	{
    		public enum SortDirection { Ascending, Descending }
    
    		public void myMethod<T>(List<ChartItemData> myList, Func<ChartItemData, T> selector, SortDirection direction)
    		{
    			List<ChartItemData> sorted = null;
    
    			if (direction == SortDirection.Ascending)
    			{
    				sorted = myList.OrderBy(selector).ToList();
    			}
    			else
    			{
    				sorted = myList.OrderByDescending(selector).ToList();
    			}
    
    			myList.Clear();
    			myList.AddRange(sorted);
    		}
    
    		public void usage()
    		{
    			List<ChartItemData> items = new List<ChartItemData>();
    
    			myMethod(items, x => x.Average, SortDirection.Ascending);
    			myMethod(items, x => x.Name, SortDirection.Ascending);
    		}
