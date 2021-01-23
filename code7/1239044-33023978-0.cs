    public class CustomDBHelper
    {
      public static IEnumerable GetElements(ApplicationDbContext db, Type type)
      {
          if (type.Equals(typeof(SongsController)))
              return db.PublishedSongs;
          else if (type.Equals(typeof(RadioStationsController)))
              return db.RadioStations;
          else
              throw new Exception("Controller not found, DBHelper");
      }
    }
