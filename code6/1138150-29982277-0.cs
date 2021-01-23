            [Authorize(Roles = SmartRoles.smclientadmin)]
            public ActionResult Index()
            {
                return View();
            }
    
            public class SmartRoles
            {
                public const string smclientadmin = "SMClientAdmin";
     
    
                public const string smclientbranchadmin = "SMClientBranchAdmin";
    
            }
