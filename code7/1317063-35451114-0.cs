    class BaseController : Controller
    {
        protected virtual ViewResult View(string viewName, BaseViewModel model)
        {   
            return base.View(viewName, model);
        }    
    }
    class BannerController : BaseController
    {
        protected virtual ViewResult View(string viewName, BaseViewModel model)
        {   
            model.PromoBannerContent = _service.GetPromoBannerContent();               
            return base.View(viewName, model);
        }    
    }
