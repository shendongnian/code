    public abstract class BaseRepository<ICanBeFoundById>
    {
      private IEnumerable<ICanBeFoundById> _xs;
    
      public static bool Find(int someID)
      {
        return xs.Any(x=>x.Id == someID)
      }
    }
