	IEnumerable<T> sorted = lstFiltered;
	var property = typeof(T).GetProperty(sort);
	if (property != null)
	{
		var getter = (Func<T, object>)Delegate
                        .CreateDelegate(typeof(Func<T, object>),
                                        property.GetGetMethod());
		if (ascending)
			sorted = sorted.OrderBy(getter);
		else
			sorted = sorted.OrderByDescending(getter);
	}
	return sorted.ToList();
