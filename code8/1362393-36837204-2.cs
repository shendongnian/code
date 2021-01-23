    public static class MyClass
    {
        public static void MyMethod()
        {
           // Some code here
        }
    }
    
    public class ReportController : BaseController
    {
           private readonly IPermissionService _permissionService;
           private readonly ICompaniesService _companyService;
    
           public ReportController(IPermissionService permissionService,
                ICompaniesService companyService)
           {
                this._permissionService = permissionService;
                this._companyService = companyService;
           }
    
            public void Reporting()
            {
                MyClass.MyMethod();
            }
    }
