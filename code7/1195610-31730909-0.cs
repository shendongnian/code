    public MyController : Controller {
    
    public ComissionBusiness comissionBusiness;
    
    public MyController(){
    comissionBusiness  = new ComissionBusiness();
    }
    
    public ActionResult Reconcile(int? id, string RevenueLoanType)
        {
    var model = comissionBusiness.Reconcile(id, revenueLoanType);
    return View(model);
    }
    }
