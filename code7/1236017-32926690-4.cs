    namespace My.Assembly.Namespace
    {
        public class FormController: SitecoreController, IHasModelFactory, IHasFormDataManager
	    {
		    public IModelFactory ModelFactory
		    {
			    get;
			    private set;
		    }
		    public IFormDataManager FormManager
		    {
			    get;
			    private set;
		    }
		    public FormController() : this((IModelFactory)Sitecore.Configuration.Factory.CreateObject("wffm/modelFactory", true), (IFormDataManager)Sitecore.Configuration.Factory.CreateObject("wffm/formDataManager", true))
		    {
		    }
		    public FormController(IModelFactory modelFactory, IFormDataManager formDataManager)
		    {
			    Assert.ArgumentNotNull(modelFactory, "modelFactory");
			    Assert.ArgumentNotNull(formDataManager, "formDataManager");
			    this.ModelFactory = modelFactory;
			    this.FormManager = formDataManager;
		    }
            [HttpGet]
            public override ActionResult Index()
            {
                return InnerController.Index();
            }
            [SubmittedFormHandler, ValidateHttpAntiForgeryToken, HttpPost]
            public virtual ActionResult Index([ModelBinder(typeof(FormModelBinder))] FormModel form)
            {
                Assert.ArgumentNotNull(form, "form");
                if (this.FormManager == null)
                {
                    return null;
                }
                string returnUrl = System.Web.HttpContext.Current.Request["returnUrl"];
                if (string.IsNullOrEmpty(returnUrl))
                {
                    returnUrl = HttpUtility.ParseQueryString(System.Web.HttpContext.Current.Request.UrlReferrer.Query)["returnUrl"];
                }
                if (!string.IsNullOrEmpty(returnUrl))
                {
                    return base.RedirectToRoute(MvcSettings.SitecoreRouteName, new
                    {
                        pathInfo = returnUrl.TrimStart(new char[]
					    {
						    '/'
					    })
                    });
                }
                return InnerController.Index(form);
            }
            private Sitecore.Forms.Mvc.Controllers.FormController InnerController
            {
                get
                {
                    Sitecore.Forms.Mvc.Controllers.FormController formController =
                        (Sitecore.Forms.Mvc.Controllers.FormController)System.Web.Mvc.ControllerBuilder.Current.GetControllerFactory().CreateController(this.ControllerContext.RequestContext, "Sitecore.Forms.Mvc.Controllers.FormController, Sitecore.Forms.Mvc");
                    formController.ControllerContext = this.ControllerContext;
                    return formController;
                }
            }
        }
    }
