    private string NextCore()
    {
    	Debug.Assert(_cachedLoot.Count > 0 && !_isRebuildRequired); // Preconditions
    	int total = DreamforceRandom.NextInteger(_total);
    	int index = _lootTotal.BinarySearch(total);
    	if (index < 0)
    		index = ~index;
    	else
    		index++;
    	return _lootName[index];
    }
    
    public string Next()
    {
    	if (_cachedLoot.Count == 0) return null; // Sanity check
    	if (_isRebuildRequired)
    	{
    		this.Rebuild();
    	}
    	return NextCore();
    }
    
    public List<string> Next(int quantity)
    {
    	var returnList = new List<string>();
    	if (_cachedLoot.Count == 0) return returnList; // Sanity check
    	if (_isRebuildRequired)
    	{
    		this.Rebuild();
    	}
    	for (int i = 0; i < quantity; i++)
    	{
    		returnList.Add(NextCore());
    	}
    	return returnList;
    }
