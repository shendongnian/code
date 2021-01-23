    public class DataModel
        {
            private static DBContext context;
            public static DBContext Context
            {
                get
                {
                    if (context == null)
                    {
                        context = new SozlukContext();
                        return context;
                    }
                    return context;
                }
            }
        }
     public class EntryRepository : IEntryRepository
        {
            DBContext _context = DataModel.Context;
            public IEnumerable<Data.Model.Entry> GetAll()
            {
                return _context.Entry.Select(x => x);
            }
        }
