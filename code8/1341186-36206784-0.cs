    [Authenticated(Roles = "read_mail", "contact_user", Order = 1)]
    public class MailController : Controller { ... }
    
    [Authenticated(Roles = "read_mail", Order = 0)]
    public ActionResult Inbox() { ... }
