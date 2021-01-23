    public class DataSourceController : Controller
    {
        HttpClient _client;
        string webapiurl = "http://localhost:56472/api/DataSource";
    
        public DataSourceController()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(webapiurl);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); 
        }
    
    
        //
        // GET: /DataSource/
        public async Task<ActionResult> Index()
        {
            var ResponseMessage = await _client.GetAsync(webapiurl);
    
            if(ResponseMessage.IsSuccessStatusCode)
            {
    
                var data = ResponseMessage.Content.ReadAsStringAsync().Result;
    
                var datasource = JsonConvert.DeserializeObject<List<DataSourceInfo>>(data);
                return View(datasource);
     
            }
    
            return View("Error");
    
        }
    }
