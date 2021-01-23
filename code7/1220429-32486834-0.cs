    using System.Web.Mvc;
    using AuthDemo.Models;
    using AuthDemo.ViewModels;
    
    namespace AuthDemo.Controllers {
        public class LoginController : Controller {
            
            [HttpGet]
            public ActionResult Index() {
                LoginViewModel viewModel = new LoginViewModel();
    
                return View("Index", viewModel);
            }
    
            [HttpPost]
            public ActionResult Logon(LoginRequest loginRequest) {
                // The default model binder has already performed basic validation against the request, so we check against that
                ActionResult result = null;
    
                if (ModelState.IsValid) {
                    // Continue with login
                    // Perform some back-end user validation
                    bool isValidLogin = false;
                    // var isValidUser = this.MembershipRepository.ValidateUser(loginRequest);
                    // TODO: perform operations based on the boolean.  For now, we pretend it's true
                    isValidLogin = true;
                    if (isValidLogin) {
                        Session["user"] = new UserModel() {
                            FirstName = "Clara",
                            LastName = "Oswald",
                            Email = "oswin@thetardis.com",
                            Id = 5
                        };
                        FormsAuthentication.SetAuthCookie(Session["user"].Email, false);
                        result = RedirectToRoute("MemberHome"); // Landing page for authenticated users.
                    } else {
                        // The user wasn't found in the repository
                        LoginViewModel viewModel = new LoginViewModel();
                        viewModel.LogOnRequest = loginRequest;
                        viewModel.LogOnResponse.Successful = false;
                        viewModel.Messages.Add("Could not find the user specified.");
                        viewModel.LogOnRequest.Attempts += 1;
                        result = View("Index", viewModel);
                    }
                } else {
                    // Login failed
                    LoginViewModel viewModel = new LoginViewModel(); // Build a new instance of the view model so we can show validation errors
                    viewModel.LogOnRequest = loginRequest;
                    viewModel.LogOnResponse.Successful = false;
                    viewModel.LogOnRequest.Attempts += 1;
                    viewModel.Messages.Add("Invalid login");
                    result = View("Index", viewModel);
    
                }
    
                return result;
            }
        }
    }
