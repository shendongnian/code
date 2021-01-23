    [Authorize]
    public class CustomBaseController : Controller{}
        
    public class AController: CustomBaseController{}
    
    public class BController: CustomBaseController{}
