    private static Pet[] SetDuplicateTo(Pet[] pets)
    {
    	int currentDup = 1;
    	foreach (var pet1 in pets)
    	{
    		if (pet1.DuplicateTo > 0) { continue; }
    		var relatedPets = (from p in pets where pet1.RelatedTo.Split(',').Select(r => r.Trim()).Contains(p.id.ToString()) select p).ToList();
    		if (relatedPets.Count > 0)
    		{
    			pet1.DuplicateTo = currentDup;
    			foreach (var pet2 in relatedPets)
    			{
    				pet2.DuplicateTo = currentDup;
    			}
    		}
    		currentDup++;
    	}
    	return pets;
    }
