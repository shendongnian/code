    public class SessionController : Controller
    {
        private readonly ISessionsService sessionService;
        public SessionController(ISessionsService sessionsService)
        {
            this.sessionService = sessionService;
        }
    
        public ActionResult SessionData(int sessionId)
        {
            var sessionData = sessionService.GetById(sessionId);
            
            /// do whatever validation you might require here
            
           var model = new SessionView(sessionData); // you could even pass the sessionId if required here
           
           return View(model);
        }
    }
