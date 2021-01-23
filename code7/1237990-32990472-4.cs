    public class DBHelper {
        public static IEnumerable GetElements(ApplicationDbContext db, System.Type type) {
            if (type == typeof(SongController)) {
                return db.PublishedSongs;
            } else if (type == typeof(StationController)) {
                return db.RadioStations;
            }
        }
    }
