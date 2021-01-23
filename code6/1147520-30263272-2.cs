    public class MyService : IMyService {
        private IDbContext _context;
        private IWordService _wordService;
        public MyService(IDbContext context, IWordService wordService) {
            _context = context;
            _wordService = wordService;
        }
        public MyObject Get(long id) {
            string word = _wordService.CurrentWord;
            // etc.
        }
    }
