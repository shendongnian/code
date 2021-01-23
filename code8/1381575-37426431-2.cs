    public class MyController : Controller
    {
        private readonly ConnectionStrings _connectionStrings;
    
        public MyController(IOptions<ConnectionString> options)
        {
            _connectionStrings = options.Value;
        }
    
        public IActionResult Get()
        {
            // Use the _connectionStrings instance now...
            using (var conn = new NpgsqlConnection(_connectionStrings.DefaultConnection))
            {
                conn.Open();
                // Omitted for brevity...
            }
        }
    }
