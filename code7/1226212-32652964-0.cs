       public class HomeController : Controller
        {
    
            public ActionResult Index()
            {
    
                /* the below is simulating a user-login... the main-thing is that it is setting a "FormsAuthentication.FormsCookieName" cookie */
    
                Employee e = new Employee();
                e.SSN = "999-99-9999";
    
                string serializedUser = JsonConvert.SerializeObject(e,
                    Formatting.None,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                    });
    
                /* so the point here is to just throw something in the "FormsAuthentication.FormsCookieName" cookie */
                FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                         1,
                         e.SSN,
                         DateTime.Now,
                         DateTime.Now.AddMinutes(15),
                         false,
                         serializedUser);
    
                string encTicket = FormsAuthentication.Encrypt(authTicket);
                HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                Response.Cookies.Add(faCookie);
    
                /* cookie is in place, now redirect */
    
                return RedirectToAction("MyHomeControllerAlternateActionResult");
            }
    
            [MyCustomMvcAuthorizeAttribute]
            public ActionResult MyHomeControllerAlternateActionResult()
            {
                IEnumerable<string> modelViaWay1 = null;
                ////////IEnumerable<string> modelViaWay2 = null;
                ////////IEnumerable<string> modelViaWay3 = null;
                string json = string.Empty;
    
                CookieContainer cookieContainer = new CookieContainer();
                HttpClientHandler handler = new HttpClientHandler
                {
                    UseCookies = true,
                    UseDefaultCredentials = true,
                    CookieContainer = cookieContainer
                };
                foreach (string cookiename in Request.Cookies)
                {
                    if (cookiename.Equals(FormsAuthentication.FormsCookieName, StringComparison.OrdinalIgnoreCase))
                    {
                        var cookie = Request.Cookies[cookiename];
                        cookieContainer.Add(new Cookie(cookie.Name, cookie.Value, cookie.Path, "localhost"));
                    }
                }
    
                using (var client = new HttpClient(handler))
                {
                    string valuesControllerUrl = Url.RouteUrl(
                        "DefaultApi",
                        new { httproute = "", controller = "Values" }, /* ValuesController */
                        Request.Url.Scheme
                    );
    
                    modelViaWay1 = client
                                .GetAsync(valuesControllerUrl)
                                .Result
                                .Content.ReadAsAsync<IEnumerable<string>>().Result;
    
                    ////////HttpResponseMessage response = client.GetAsync(valuesControllerUrl).Result;
                    ////////json = response.Content.ReadAsStringAsync().Result;
    
                    ////////modelViaWay2 = JsonConvert.DeserializeObject<IEnumerable<string>>(json);
                    ////////modelViaWay3 = response.Content.ReadAsAsync<IEnumerable<string>>().Result;
    
                }
    
                return View(); /* this will throw a "The view 'MyHomeControllerAlternateActionResult' or its master was not found or no view engine supports the searched locations" error, but that's not the point of this demo. */
            }
        }
