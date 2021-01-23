	public static class extCluster
	{
		public static IEnumerable<KeyValuePair<bool, T[]>> Clusterize<T>(this IEnumerable<T> self, Func<T, bool> clusterizer)
		{
			// Prepare temporary data
			var bLastCluster = false;
			var cluster = new List<T>();
			// loop all items
			foreach (var item in self)
			{
				// Compute cluster kind
				var bItemCluster = clusterizer(item);
				// If last cluster kind is different from current
				if (bItemCluster != bLastCluster)
				{
					// If previous cluster was not empty, return its items
					if (cluster.Count > 0)
						yield return new KeyValuePair<bool, T[]>(bLastCluster, cluster.ToArray());
					// Store new cluster kind and reset items
					bLastCluster = bItemCluster;
					cluster.Clear();
				}
				// Add current item to cluster
				cluster.Add(item);
			}
			// If previous cluster was not empty, return its items
			if (cluster.Count > 0)
				yield return new KeyValuePair<bool, T[]>(bLastCluster, cluster.ToArray());
		}
	}
	// sample
	static class Program
	{
		public class Item
		{
			public Item(int id, int sequence, int _customIndex)
			{
				ID = id; Sequence = sequence; customIndex = _customIndex;
			}
			public int ID, Sequence, customIndex;
		}
		[STAThread]
		static void Main(string[] args)
		{
			var aItems = new[]
			{
				new Item(1, 1, 0),
				new Item(2, 2, 0),
				new Item(3, 3, 2),
				new Item(4, 4, 1),
				new Item(5, 5, 0)
			};
			// Split items into clusters
			var aClusters = aItems.Clusterize(item => item.customIndex != 0);
			// Explode clusters and sort their items
			var result = aClusters
				.SelectMany(cluster => cluster.Key
				? cluster.Value.OrderBy(item => item.customIndex)
				: cluster.Value.OrderBy(item => item.Sequence));
		}
	}
