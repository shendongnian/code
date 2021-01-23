    public class CommunicationsController : Controller
        {
    
            private IEmailSender _sender;
            private FormSettings ConfigSettings { get; set; }
    
            public CommunicationsController(IEmailSender sender, IOptions<FormSettings> settings)
            {
                _sender = sender;
                ConfigSettings = settings.Value;
            }
    public async Task<ActionResult> ContactUsFormSubmit(ContactUs request)
            {
                ...
                        request.EmailSent = await _sender.SendEmail(new Email() { TemplateId = 3, Body = JsonConvert.SerializeObject(request) }, ConfigSettings);
                ...
            }
