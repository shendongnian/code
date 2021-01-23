    public class TestController : ApiController
    {
        [HttpGet]
        public async Task<IHttpActionResult> TestMethod(...)
        {
            string _apiUrl = String.Format("...");
            string _baseAddress = "...";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync(_apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    string responseBodyAsText = await response.Content.ReadAsStringAsync();
                    return Json(responseBodyAsText);
                }
            }
            return NotFound();
        }
    }
