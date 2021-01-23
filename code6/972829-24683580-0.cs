        public async Task <ActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54568/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    
                HttpResponseMessage response = await client.GetAsync("api/Values/"); //API controller name
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<YourReturnDataType>();
                    if (result != null)
                        var output = result;
                }
            }
    
            return View("Return your model here");
        }
