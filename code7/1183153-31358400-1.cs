    enter code here public abstract class BaseController<T, M> : Controller
        where M : new()
    {
        public BaseController(IRepository<T> repository)
        {
            this._repository = repository;
            ViewBag.CurrentUser = CurrentUser;
        }
        protected User CurrentUser
        {
            get
            {
                if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    return Mapper.Map<User>(System.Web.HttpContext.Current.User.Identity);
                }
                return null;
            }
        }
        protected virtual int PageSize
        {
            get { return 5; }
        }
        protected IRepository<T> _repository;
        public virtual ActionResult Index(int? currentPage)
        {
            var entities = _repository.GetAll();
            List<M> model = new List<M>();
            foreach (var currentEntity in entities)
            {
                model.Add(Mapper.Map<M>(currentEntity));
            }
            int pageNumber = (currentPage ?? 1);
            return View(model.ToPagedList(pageNumber, PageSize));
        }
        [HttpGet]
        public virtual ActionResult Add()
        {
            return View(new M());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public virtual ActionResult Add(M model)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(Mapper.Map<T>(model), CurrentUser);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public virtual ActionResult Update(int modelId)
        {
            T domainModelEntity = _repository.GetById(modelId);
            M model = Mapper.Map<M>(domainModelEntity);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public virtual ActionResult Update(M model)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(Mapper.Map<T>(model), CurrentUser);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public virtual ActionResult Delete(int modelId)
        {
            _repository.Delete(modelId);
            return RedirectToAction("Index");
        }
    }
