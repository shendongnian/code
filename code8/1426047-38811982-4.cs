    public class LoginController : Controller
    {
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Validate(User user)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                using (var connection = new SqlConnection(cs))
                {
                    string commandText = "SELECT Username FROM [User] WHERE Username=@Username AND Password = @Password";
                    using (var command = new SqlCommand(commandText, connection))
                    {
                        command.Parameters.AddWithValue("@Username", user.Username);
                        command.Parameters.AddWithValue("@Password", user.Password);
                        connection.Open();
                        string userName = (string)command.ExecuteScalar();
                        if(!String.IsNullOrEmpty(userName))
                        {
                            System.Web.Security.FormsAuthentication.SetAuthCookie(user.Username, false);
                            return RedirectToAction("Index", "Home");
                        }
                        TempData["Message"] = "Login failed.User name or password supplied doesn't exist.";
                        connection.Close();
                    }
                }
            }
            catch(Exception ex)
            {
                TempData["Message"] = "Login failed.Error - " + ex.Message;
            }
            return RedirectToAction("Index");
        }
    }
