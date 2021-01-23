    public class ManageController : BaseController
    {
        private IAccountContext _db          
        
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            _db = new MainContext(_connectionName);
        }
        
        public ActionResult MyAction()
        {
            // now you have access _db variable
        }
        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
