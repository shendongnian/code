    public class TestController : Controller
    {
        // GET: Test
        public async Task<ActionResult> Index()
        {
            DateTime BeginDate = new DateTime(2015, 1, 1);
            DateTime EndDate = new DateTime(2015, 12, 31);
            string AuthenticatedUser = "123473306";
            bool RecognizedOrSubmitted = true;
            
            string VPath = "api/WebAPI/GetAllRecognitionsBySupervisorAll";
            ViewModels.AllRecognitionsbyAllSupervisors  AllRByAllS = new ViewModels.AllRecognitionsbyAllSupervisors(BeginDate, EndDate, AuthenticatedUser, RecognizedOrSubmitted);
            var baseUrl = GetBaseUrl();//Implement this to get your base address 
            var client = new HttpClient();//Use this to call web api
            client.BaseAddress = baseUrl;
            //post viewmodel to web api
            var response = await client.PostAsync(VPath, AllRByAllS);
            return View();
      }
    }
