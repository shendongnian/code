    public class HomeController : Controller
    {
       private readonly IEmailService _emailService;
       private readonly string _emailContact;
      /// The framework will inject an instance of an IEmailService implementation.
       public HomeController(IEmailService emailService)
       {
          _emailService = emailService;
          _emailContact = System.Configuration.ConfigurationManager.
                       AppSettings.Get("ContactEmail");
       }
    
       [HttpPost]
       public void EmailSupport([FromBody] string message)
       {
          if (!ModelState.IsValid)
          {
             Context.Response.StatusCode = 400;
          }
          else
          {
             _emailService.Send(_emailContact, message);
