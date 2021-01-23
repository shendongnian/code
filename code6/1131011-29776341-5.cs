	public class MvcController : Controller
	{
		private IService _service;
        private IUserValidator _userValidator;
		public MvcController(IService service, IUserValidator userValidator) // depending on abstraction
		{
			_service = service;
            _userValidator = userValidator;
		}
	    public ActionResult MyAction(string userValue)
        {
        	if (!_userValidator.CheckSomeCondition(userValue))
        	{ 	//Something failed. Try again.
            	return View();
        	}
           	User user = _service.GetUser();
            user.UserValue = userValue;
        	_service.Update(user);         
        	return RedirectToAction("Success");
        }
	}
