    namespace MyApp.ApiControllers
    {
        public class RegistrationController : ApiController
        {
            private RegistrationService registrationService;
    
            public RegistrationController()
            {
                this.registrationService = new RegistrationService();
            }
        
            public HttpResponseMessage Post([FromBody]PilotModel pilot)
            {
                this.registrationService.RegisterPilot(pilot);
    
                var response = Request.CreateResponse<PilotModel>(HttpStatusCode.Created, pilot);
        
                return response;
            }
        }
    }
