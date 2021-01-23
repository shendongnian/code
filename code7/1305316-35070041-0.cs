    public class AuthController : Controller
    {
        private readonly string _casHost = System.Configuration.ConfigurationManager.AppSettings["CasHost"];
        private readonly string _casXMLNS = "http://www.yale.edu/tp/cas";
    
        private readonly IBannerIdentityService _bannerIdentityService;
    
        public ILogger Logger { get; set; }
    
        public AuthController(IBannerIdentityService bannerIdentityService)
        {
            _bannerIdentityService = bannerIdentityService;
        }
    
        //
        // GET: /Auth/
        public ActionResult Index()
        {
            return RedirectToAction("Login");
        }
    
        //
        // GET: /Auth/Login
        public ActionResult Login(string ticket, string ReturnUrl)
        {
            // Make sure CasHost is specified in web.config
            if (String.IsNullOrEmpty(_casHost))
                Logger.Fatal("Could not find CasHost in web.config. Please specify this value for authentication.");
    
            string strService = Request.Url.GetLeftPart(UriPartial.Path);
    
            // First time through there is no ticket=, so redirect to CAS login
            if (String.IsNullOrWhiteSpace(ticket))
            {
                if (!String.IsNullOrWhiteSpace(ReturnUrl))
                {
                    Session["ReturnUrl"] = ReturnUrl;
                }
    
                string strRedirect = _casHost + "login?" + "service=" + strService;
    
                Logger.Debug("Initializing handshake with CAS");
                Logger.DebugFormat("Redirecting to: {0}", strRedirect);
    
                return Redirect(strRedirect);
            }
    
            // Second time (back from CAS) there is a ticket= to validate
            string strValidateUrl = _casHost + "serviceValidate?" + "ticket=" + ticket + "&" + "service=" + strService;
    
            Logger.DebugFormat("Validating ticket from CAS at: {0}", strValidateUrl);
    
            XmlReader reader = XmlReader.Create(new WebClient().OpenRead(strValidateUrl));
            XDocument xdoc = XDocument.Load(reader);
            XNamespace xmlns = _casXMLNS;
    
            Logger.DebugFormat("CAS Response: {0}", xdoc.ToString());
            Logger.Debug("Parsing XML response from CAS");
    
            var element = (from serviceResponse in xdoc.Elements(xmlns + "serviceResponse")
                            from authenticationSuccess in serviceResponse.Elements(xmlns + "authenticationSuccess")
                            from user in authenticationSuccess.Elements(xmlns + "user")
                            select user).FirstOrDefault();
    
            string strNetId = String.Empty;
    
            if (element != null)
                strNetId = element.Value;
    
            if (!String.IsNullOrEmpty(strNetId))
            {
                Logger.DebugFormat("User '{0}' was validated successfully", strNetId);
                Logger.DebugFormat("Loading user data for '{0}'", strNetId);
    
                // Get banner data
                var bannerUser = _bannerIdentityService.GetBannerIdentityByNetId(strNetId);
    
                // Make sure banner user isnt null
                if (bannerUser == null)
                    throw new ArgumentOutOfRangeException(String.Format("Could not found any banner records for the Net ID ({0}).", strNetId));
    
                Logger.DebugFormat("Logging in user '{0}' as a system user.", strNetId);
    
                Response.Cookies.Add(GetFormsAuthenticationCookie(bannerUser));
            }
            else
            {
                return HttpNotFound();
            }
    
            if (Session["ReturnUrl"] != null)
            {
                ReturnUrl = Session["ReturnUrl"].ToString();
                Session["ReturnUrl"] = null;
            }
    
            if (String.IsNullOrEmpty(ReturnUrl) && Request.UrlReferrer != null)
                ReturnUrl = Server.UrlEncode(Request.UrlReferrer.PathAndQuery);
    
            if (Url.IsLocalUrl(ReturnUrl) && !String.IsNullOrEmpty(ReturnUrl))
            {
                return Redirect(ReturnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
        }
    
        private HttpCookie GetFormsAuthenticationCookie(BannerIdentity identity)
        {
            Logger.DebugFormat("Building FormsAuthentication Cookie for user: '{0}'", identity.NetId.Value);
    
            UserPrincipalPoco pocoModel = new UserPrincipalPoco();
            pocoModel.BannerIdentity = identity;
    
            JavaScriptSerializer serializer = new JavaScriptSerializer();
    
            string userData = serializer.Serialize(pocoModel);
    
            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                1,
                identity.NetId.Value,
                DateTime.Now,
                DateTime.Now.AddMinutes(15),
                false,
                userData);
    
            string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
    
            return new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
        }
    }
