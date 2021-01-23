	public static class Aggregator
	{
		public static AggregatedList Aggregate(List objects)
		{
			// aggregate objects to aggregatedlist and set the aggregationInfo
		}
		public static List Deaggregate(AggregatedList aggregatedList)
		{
			// use info from the aggregatedList
		}
	}
	public class AggregatedList
	{
		public AggregationInfo AggregationInfo { get; set; }
		public List AggregatedObjects { get; set; }
	} 
