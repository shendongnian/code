         public static Task RunAsync()
         {
            string pathValue = WebConfigurationManager.AppSettings["R2G2APIUrl"];
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(pathValue);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var id = "12421";
                HttpResponseMessage response = client.GetAsync("api/products/1").Result;
                var jobid = new Jobs() { Job_ID = id };
                response = client.PostAsJsonAsync("api/products", jobid).Result;
                if (response.IsSuccessStatusCode)
                {
                    Uri gizmoUrl = response.Headers.Location;
                }
            }
        }
