	public decimal SumAll(List<block> blocks, int id)
	{
		return SumAll(id, blocks.ToLookup(x => x.parentid, x => x.id), blocks.ToDictionary(x => x.id));
	}
	
	private decimal SumAll(int id, ILookup<int?, int> lookup, Dictionary<int, block> map)
	{
		return map[id].value + lookup[id].Select(x => SumAll(x, lookup, map)).Sum();
	}
