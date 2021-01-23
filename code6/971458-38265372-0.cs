      public async Task<ActionResult> Country()
        {
            var model = new Country();
         
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44305/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                ViewBag.country = "";
                HttpResponseMessage response = await client.GetAsync("api/v1/doctor/country");
                List<string> li;
                if (response.IsSuccessStatusCode)
                {
                    Country co = new Models.Country();
                    li = await response.Content.ReadAsAsync<List<string>>();
                    ViewBag.country = li;
                }
            }
            return View();
        }
