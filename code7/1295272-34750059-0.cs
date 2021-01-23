    public void A(Guid agentId)
    {
        AnotherA(agentId, true);
    }
    
    private Entry B(IAgent agent)
    {
        return AnotherA(agent.Id, false);
    }
    private Entry AnotherA(Guid agentId, bool a)
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
