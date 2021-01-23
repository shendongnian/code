	public class CommunicationsController : Controller
	{
		private IEmailSender _sender;
	
		public CommunicationsController(IEmailSender sender)
		{
			_sender = sender;
		}
	
		public async Task<ActionResult> ContactUsFormSubmit(ContactUs request)
		{
	            ...
	                    request.EmailSent = await _sender.SendEmail(new Email() { TemplateId = 3, Body = JsonConvert.SerializeObject(request) });
	            ...
	    }
	}
