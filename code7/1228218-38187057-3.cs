    public abstract class BaseInterimController : Controller {
        protected IInterimIdentityProvider identifier;
        public BaseInterimController(IInterimIdentityProvider identifier) {
            this.identifier = identifier;
        }
    
        protected string InterimName {
            get { return MultiInterim.GetInterimName(identifier.InterimIdentifier); }
        }
    
        //This can be refactored to the code above or use what you had before
        //internal virtual string InterimIdentifier {
        //    get { return identifier.InterimIdentifier; }
        //}
    }    
    public class AccountController : BaseInterimController
    {
        public AccountController(IInterimIdentityProvider identifier) 
            : base(identifier){ }
    
        [HttpPost]
        [AllowAnonymous]
        [ValidateInput(false)]
        [Route(@"{InterimIdentifier:regex([a-z]{7}\d{4})}/Account/Signin")]
        public ActionResult Signin(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var identity = Authentication.SignIn(model.Username,
                    model.Password) as LegIdentity;
    
                if (identity != null && identity.IsAuthenticated)
                {
                    return Redirect(model.ReturnUrl);
                }
                else
                {
                    // Sign in failed
                    ModelState.AddModelError("",
                        Authentication.ExternalSignInFailedMessage);
                }
            }
            return View(model);
        }
    }
