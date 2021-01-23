    public class Customer
    {
        [SearchField( Mode = SearchMode.StartsWith )]
        public string FirstName { get; set; }
        public string DontSearchMe { get; set; }
        [SearchField( Mode = SearchMode.StartsWith | SearchMode.EndsWith )]
        public string Phone { get; set; }
    }
    public abstract class Repository<T>
    {
        public IEnumerable<T> Search( string searchString )
        {
            var predicate = //generate predicate from attributed properties on class T and searchString parameter
            return _context.Set<T>().Where( predicate ).ToList();
        }
    }
