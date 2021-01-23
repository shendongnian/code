    public class MyContext:DbContext
    {
        private readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        
        public MyContext()
               : base("<connectionstring>")
        {
            Database.Log = log => _logger.Debug(log);
        }
    }
