    public IEnumerable<DomainColour> GetWhere(Expression<Func<DomainColour, bool>> predicate)
    {
    	var map = new ExpressionMap()
    		.Add<DomainColour, DtoColour>()
    		.Add((DomainColour c) => c.People, (DtoColour c) => c.FavouriteColours.Select(fc => fc.Person))
    		.Add<DomainPerson, DtoPerson>();
    	var mappedPredicate = ((Expression<Func<DtoColour, bool>>)map.Map(predicate));
    	return Colours.Where(mappedPredicate.Compile()).Select(c => new DomainColour(c.Name)).ToList();
    }
