    var foundDuplicates = new List<fixFirstDuplicate>();
	foreach (var combinationToFind in conLines)
	{
		// "They will be separated by at least one space."
		var parameters = combinationToFind.Split(new[] { ' ' },                  
                             StringSplitOptions.RemoveEmptyEntries);
		
		var duplicatesForCombination = firstDuplicate.Where(d => 
                                                    d.firstParam == parameters[0]
                                                && d.secondParam == parameters[1]);
		
		foundDuplicates.AddRange(duplicatesForCombination);
	}
