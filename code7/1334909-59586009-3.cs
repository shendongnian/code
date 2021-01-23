    public class ResourceLocker
    {
       private Dictionary<string, SemaphoreSlim> _lockers = null;
    
       private object lockObj = new object();
    
       public ResourceLocker()
       {
          _lockers = new Dictionary<string, SemaphoreSlim>();
       }
       public SemaphoreSlim GetOrCreateLocker(string resource)
       {
           lock (lockObj)
           {
              if (!_lockers.ContainsKey(resource))
              {
                 _lockers.Add(resource, new SemaphoreSlim(1, 1));
              }
                 return _lockers?[resource];
            }
        }
    
        public bool ReleaseLocker(string resource)
        {
           lock (lockObj)
           {
             if (_lockers.ContainsKey(resource))
             {
               var locker = _lockers?[resource];
    
               if (locker != null)
               {
                 locker.Release();
    
                 return true;
                }
                 _lockers.Remove(resource);
              }
              return false;
            }//lock
          }
     }
    
