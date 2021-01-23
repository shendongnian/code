	void find(IDictionary<string, IEnumerable<string>> collection, string element)
	{
		// I need to remove some values, like this
		IEnumerable<string> value = collection[element];;
		IList<string> ilist = value as IList<string>;
        if (ilist != null && !(value is string[]))
		{
			// Remove the last element
			ilist.RemoveAt(ilist.Count - 1);
		}
		else
		{
			ilist = value.ToList();
			ilist.RemoveAt(ilist.Count - 1);
			collection[element] = ilist;
		}
	}
