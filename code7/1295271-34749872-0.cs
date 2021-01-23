    private Entry B(IAgent agent, bool foo)
    {
         var updateCompletionSource = C(agent.Id);
         try
         {
              var cacheEntry = UpdateAgentMetadataCacheEntry(agent, foo, false);
              updateCompletionSource.SetResult(cacheEntry);
              return cacheEntry;
          }
          catch (Exception e)
          {
              updateCompletionSource.SetException(e);
              return GetPreviousCacheEntry();
          }
    }
