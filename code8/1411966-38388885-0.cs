	public IEnumerable<Sample> GetFiltered(
		IEnumerable<Sample> samples, string property, string value)
	{
		var map = new Dictionary<string, Func<string, Func<Sample, bool>>>()
		{
			{ "Description", v => s => s.Description == v },
			{ "Id", v => s => s.Id == int.Parse(v) },
		};
		return samples.Where(map[property](value));
	}
