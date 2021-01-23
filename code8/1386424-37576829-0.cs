    public abstract class BaseController : Controller
    {
        public virtual UnitOfWork UnitOfWork
        {
            get
            {
                return unitOfWork;
            }
        }
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            if (unitOfWork == null)
            {
                unitOfWork = new UnitOfWork(HttpContext.GetOwinContext().Get<ProjectPlannerContext>());
            }
        }
        #region Private members
        private UnitOfWork unitOfWork;
        #endregion
    }
