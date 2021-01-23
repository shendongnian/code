    public class BranchController : Controller
    {
        private IBusinessService service;
        public BranchController()
        {
            this.service = new BusinessService(db);
        }
        public ActionResult Reconcile(int? id, string RevenueLoanType)
        {
            var model = new CommissionVM
            {
                BranchGrossTotal = this.service.GetBranchGrossTotal(id, RevenueLoanType),
                ...
            };
            return View(model);
        }
    }
