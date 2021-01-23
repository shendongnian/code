    public class DataRepository()
    {
        private NorthwindContext _context;
        public DataRepository( NorthwindContext context )
        {
            this._context = context;
        }
        public Order GetOrder( int id )
        {
            return this._context.....
        }
