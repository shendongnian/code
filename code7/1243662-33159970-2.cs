    private Pet[] SetDuplicateTo(Pet[] pets)
    {
    	int currentDupNumber = 1;
    	foreach (var pet1 in pets)
    	{
    		if (pet1.DuplicateTo > 0) { continue; }
    		var relatedPets = (from p in pets where pet1.RelatedTo.Split(',').Select(r => r.Trim()).Contains(p.id.ToString()) select p).ToList();
    		if (relatedPets.Count > 0)
    		{
    			pet1.DuplicateTo = currentDupNumber;
    			foreach (var pet2 in relatedPets)
    			{
    				pet2.DuplicateTo = currentDupNumber;
    			}
    		}
    		currentDupNumber++;
    	}
    	return pets;
    }
