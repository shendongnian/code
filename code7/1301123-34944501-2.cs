	public IEnumerable<int> SearchBytes(byte[] haystack, byte[] needle)
	{
		return
			haystack
				.Select((x, n) => new
				{
					n,
					found = haystack.Skip(n).Take(needle.Length).SequenceEqual(needle)
				})
				.Where(x => x.found)
				.Select(x => x.n)
				.Reverse();
	}
