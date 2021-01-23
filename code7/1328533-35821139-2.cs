	public IEnumerable<string> FormatTree(ILookup<int?, Category> lookup, int? parent, int indent)
	{
		return
			from c in lookup[parent]
			from t in new[] { "".PadLeft(indent * 4) + c.Title }.Concat(FormatTree(lookup, c.ID, indent + 1))
			select t;
	}
