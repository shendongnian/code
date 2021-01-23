    public class TestController : Controller
    {
        public async Task <ActionResult> Index()
        {
            var model = new CustomerViewModel();
                          
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54568/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    
                HttpResponseMessage response = await client.GetAsync("api/Values/");
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<IEnumerable<string>>();
                    if (result != null)
                        model.Customers = result;
                }
            }
    
            return View(model);
        }
    } 
