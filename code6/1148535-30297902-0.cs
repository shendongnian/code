    public class MyController : Controller
    {
        private EntitiesModel _dbContext;
        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);
            this._dbContext = ContextFactory.GetContextPerRequest();
            //the problem is disappeared after add this line
            var obj = this._dbContext.AnyTable.FirstOrDefault(); 
        }
		
		public ActionResult Index()
        {
		    var q = _dbContext.AnyTable.ToList();
            return View(q); //Now It works like charm
        }
	}
	
    public class ContextFactory
    {
        private static readonly string ContextKey = typeof(EntitiesModel).FullName;
        public static EntitiesModel GetContextPerRequest()
        {
            var httpContext = HttpContext.Current;
            if (httpContext == null)
            {
                return new EntitiesModel();
            }
            var context = httpContext.Items[ContextKey] as EntitiesModel;
            if (context != null) return context;
            context = new EntitiesModel();
            httpContext.Items[ContextKey] = context;
            return context;
        }
    }
