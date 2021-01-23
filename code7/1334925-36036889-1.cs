        [Authorize]
        public class DepositController : Controller
        {
            private readonly IAccountLimit _accountLimit;
            private readonly ICustomerService _customerService;
    
            public DepositController(ICustomerService customerService, IAccountLimit accountLimit)
            {
                _accountLimit = accountLimit;
                _customerService = customerService;
            }
    
            public ActionResult GetWithdrawalLimit()
            {
                var customer = _customerService.Find(User.Identity.Name);
    
                return View(_accountLimit.RemainingWithdrawal(customer.Id));
            }
        }
