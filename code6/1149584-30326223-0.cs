    public abstract BaseViewModel()
    {
        public int TenantId { get; set; }
        
        public void SetAuthInfo(BaseController controller)
        {  
            this.TenantId = controller.TenantId;
        }
    }
    public MyViewModel() : BaseViewModel
    // no other changes needed to MyViewModel
    ...
    public ActionResult Index()
    {
        var model = new MyViewModel();
        model.SetAuthInfo(this);
        return View(model);
    }
