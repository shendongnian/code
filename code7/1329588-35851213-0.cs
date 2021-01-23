    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            DateTime BeginDate = new DateTime(2015, 1, 1);
            DateTime EndDate = new DateTime(2015, 12, 31);
            string AuthenticatedUser = "123473306";
            bool RecognizedOrSubmitted = true;
            string baseUrl = GetBaseUrl();
            var client = new HttpClient();
            client.BaseUrl = baseUrl;
            string VPath = "api/WebAPI/GetAllRecognitionsBySupervisorAll";
            ViewModels.AllRecognitionsbyAllSupervisors  AllRByAllS = new ViewModels.AllRecognitionsbyAllSupervisors(BeginDate, EndDate, AuthenticatedUser, RecognizedOrSubmitted);
            var response = await client.PostAsync(VPath, AllRByAllS);
            return View();
      }
    }
