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
                var responseMessage = await client.GetAsync(_apiUrl);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var response = Request.CreateResponse(HttpStatusCode.OK);
                    response.Content = responseMessage.Content;
                    return ResponseMessage(response);
                }
            }
            return NotFound();
        }
    }
