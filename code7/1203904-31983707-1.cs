	public class BaseController
	{
		protected MyDbContext DataContext { get; set; }
		protected readonly ILog logger;
		public BaseController()
		{
			DataContext = new MyDbContext();
			logger = LogManager.GetLogger(GetType());
			DataContext.Database.Log = (dbLog => logger.Debug(dbLog));
			// ...
		}
		
		//...
			
	}
