    public class RegionStore
    {
      // I'm using int as the identifier for a region.
      // Obviously this must be some type that can serve as
      // an ID according to your application's logic.
      private Dictionary<int, WeakReference<Region>> _store = new Dictionary<int, WeakReference<Region>>();
      private const int TrimThreshold = 1000; // Profile to find good value here.
      private int _addCount = 0;
      public bool TryGetRegion(int id, out Region region)
      {
        WeakReference<Region> wr;
        if(!_store.TryGetValue(id, out wr))
          return false;
        if(wr.TryGetTarget(out region))
          return true;
        // Clean up space in dictionary.
        _store.Remove(id);
        return false;
      }
      public void AddRegion(int id, Region region)
      {
        if(++_addCount >= TrimThreshold)
          Trim();
        _store[id] = new WeakReference<Region>(region);
      }
      public void Remove(int id)
      {
        _store.Remove(id);
      }
      private void Trim()
      {
        // Remove dead keys.
        // Profile to test if this is really necessary.
        // If you were fully implementing this, rather than delegating to Dictionary,
        // you'd likely see if this helped prior to an internal resize.
        _addCount = 0;
        var keys = _store.Keys.ToList();
        Region region;
        foreach(int key in keys)
          if(!_store[key].TryGetTarget(out wr))
            _store.Remove(key);
      }
    }
