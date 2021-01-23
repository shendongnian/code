    	private static readonly TCObjectComparer<OwnedItem> comparer
			= new TCObjectComparer<OwnedItem>();
		/// <summary>
		/// caching dependencies in order to increase performance
		/// </summary>
		private static readonly IDictionary<string, IEnumerable<OwnedItem>> dependencies
			= new Dictionary<string, IEnumerable<OwnedItem>>();
		/// <summary>
		/// recursively find OwnedItems this oi depends upon
		/// see http://stackoverflow.com/questions/37614469/how-to-recurse-over-items-having-cyclic-dependencies
		/// </summary>
		/// <param name="oi"></param>
		/// <returns></returns>
		private static IEnumerable<OwnedItem> GetDependencies(OwnedItem oi)
		{
			if (null == oi)
			{
				return Enumerable.Empty<OwnedItem>();
			}
			if (dependencies.ContainsKey(oi.UniqueId))
			{
				return dependencies[oi.UniqueId];
			}
			var resultExploredNodes = new HashSet<OwnedItem>(comparer);
			var nodesToExplore = new Queue<OwnedItem>();
			nodesToExplore.Enqueue(oi);
			while (nodesToExplore.Count > 0)
			{
				var node = nodesToExplore.Dequeue();
				resultExploredNodes.Add(node);
				// add nodes not already visited to nodesToExplore
				node.AllUsedOwnedItemsToBeIncluded
					.Except(resultExploredNodes, comparer)
					.ForEach(n => nodesToExplore.Enqueue(n));
			}
			dependencies[oi.UniqueId] = resultExploredNodes;
			return resultExploredNodes;
		}
