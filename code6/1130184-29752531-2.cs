    public interface IDynamicNodeProvider
    {
      IEnumerable<DynamicNode> GetDynamicNodeCollection();
      CacheDescription GetCacheDescription();
    }
