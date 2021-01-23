    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;
    using Microsoft.AspNet.Identity;
    using MixedAuth;
    
    namespace EmployeePortal.Web.Controllers
    {
        [Authorize]
        public partial class AccountController : BaseController
        {
            //
            // POST: /Account/WindowsLogin
            [AllowAnonymous]
            [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
            public ActionResult WindowsLogin(string userName, string returnUrl)
            {
                if (!Request.LogonUserIdentity.IsAuthenticated)
                {
                    return RedirectToAction("Login");
                }
    
                var loginInfo = GetWindowsLoginInfo();
    
                // Sign in the user with this external login provider if the user already has a login
                var user = UserManager.Find(loginInfo);
                if (user != null)
                {
                    SignIn(user, isPersistent: false);
                    return RedirectToLocal(returnUrl);
                }
                else
                {
                    return RedirectToAction("Login", new RouteValueDictionary(new { controller = "Account", action = "Login", returnUrl = returnUrl }));
                }
            }
    
            //
            // POST: /Account/WindowsLogOff
            [HttpPost]
            [ValidateAntiForgeryToken]
            public void WindowsLogOff()
            {
                AuthenticationManager.SignOut();
            }
    
            //
            // POST: /Account/LinkWindowsLogin
            [AllowAnonymous]
            [HttpPost]
            public async Task<ActionResult> LinkWindowsLogin()
            {
                int userId = HttpContext.ReadUserId();
    
                //didn't get here through handler
                if (userId <= 0)
                    return RedirectToAction("Login");
    
                HttpContext.Items.Remove("windows.userId");
    
                //not authenticated.
                var loginInfo = GetWindowsLoginInfo();
                if (loginInfo == null)
                    return RedirectToAction("Manage");
    
                //add linked login
                var result = await UserManager.AddLoginAsync(userId, loginInfo);
    
                //sign the user back in.
                var user = await UserManager.FindByIdAsync(userId);
                if (user != null)
                    await SignInAsync(user, false);
    
                if (result.Succeeded)
                    return RedirectToAction("Manage");
    
                return RedirectToAction("Manage", new { Message = ManageMessageId.Error });
            }
    
            #region helpers
            private UserLoginInfo GetWindowsLoginInfo()
            {
                if (!Request.LogonUserIdentity.IsAuthenticated)
                    return null;
    
                return new UserLoginInfo("Windows", Request.LogonUserIdentity.User.ToString());
            }
            #endregion
        }
    
        public class WindowsLoginConfirmationViewModel
        {
            [Required]
            [Display(Name = "User name")]
            public string UserName { get; set; }
        }
    }
