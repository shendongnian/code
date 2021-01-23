    public void A(Guid agentId)
    {
        var agent = _agentsProvider.GetAgentById(agentId);
        AnotherA(agent, true);
    }
    
    private Entry B(IAgent agent)
    {
        return AnotherA(agent, false);
    }
    private Entry AnotherA(IAgent agent, bool a)
    {
	    try
    	{
             var cacheEntry = UpdateAgentMetadataCacheEntry(agent, a, false);
	    	 updateCompletionSource.SetResult(cacheEntry);
             return cacheEntry;
	    }
    	catch (Exception e)
	    {
            updateCompletionSource.SetException(e);
		    return GetPreviousCacheEntry();
	    }
    }
