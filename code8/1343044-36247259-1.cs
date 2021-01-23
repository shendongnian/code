    static Expression<Func<Person, bool>> AbilityFilter(List<int> values, int index)
    {
    	var value = values[index];
    	return p => p.AllAbilities.OrderBy(a => a.Id).Skip(index).Take(1).Any(a => a.Value > value);
    }
