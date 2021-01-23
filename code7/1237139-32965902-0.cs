    public class MyCustomRepository
    {
        private readonly MyCustomContext _context;
        public MyCustomRepository(MyCustomContext context)
        {
            _context = context;
        }
    
        public IEnumerable<MyQueryResultRow> GetResultRows()
        {
            return _context.ResultsRows.Where(r => r.Id > 10); // Here you can add some restrictions
        }
    }
