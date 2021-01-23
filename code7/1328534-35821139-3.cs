	public IEnumerable<string> FormatTree2(ILookup<int?, Category> lookup, int? parent, int indent)
	{
		foreach (var category in lookup[parent])
		{
			yield return "".PadLeft(indent * 4) + category.Title;
			foreach (var descendant in FormatTree2(lookup, category.ID, indent + 1))
			{
				yield return descendant;
			}
		}
	}
