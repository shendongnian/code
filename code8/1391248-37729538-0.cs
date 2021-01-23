    public interface IThingRepository
    {
      IReadOnlyCollection<Thing> GetThings();
    }
    public class ThingRepository : IThingRepository
    {
      //...
    }
    public class ThingRepositoryCache : IThingRepository
    {
      IThingRepository realRepository;
      MemoryCache cache;
    
      public ThingRepositoryCache(IThingRepository realRepository,
        MemoryCache cache)
      {
        this.realRepository = realRepository;
        this.cache = cache;
      }
    
      public IReadOnlyCollection<Thing> GetThings()
      {
        return cache["things"] ?? cache["things"] = this.realRepository.GetThings();
      }
    }
