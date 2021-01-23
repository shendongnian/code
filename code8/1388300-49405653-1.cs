    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
    	{
            return View();
    	}
 
	[HttpPost]
    public ActionResult Index(EmailModel model)
	{
        using (MailMessage mm = new MailMessage(model.Email, model.To))
    	{
        	mm.Subject = model.Subject;
        	mm.Body = model.Body;
            if (model.Attachment.ContentLength > 0)
        	{
                string fileName = Path.GetFileName(model.Attachment.FileName);
            	mm.Attachments.Add(new Attachment(model.Attachment.InputStream, fileName));
        	}
        	mm.IsBodyHtml = false;
            using (SmtpClient smtp = new SmtpClient())
        	{
            	smtp.Host = "smtp.gmail.com";
            	smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential(model.Email, model.Password);
            	smtp.UseDefaultCredentials = true;
            	smtp.Credentials = NetworkCred;
            	smtp.Port = 587;
            	smtp.Send(mm);
            	ViewBag.Message = "Email sent.";
        	}
    	}
 
        return View();
	    }
    }
