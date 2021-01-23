            var httpClient = new HttpClient();
            HttpResponseMessage response = httpClient.GetAsync("http://search.twitter.com/search.json?q=xamarin&rpp=10&include_entities=false&result_type=mixed").Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                System.Diagnostics.Debug.WriteLine(data);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine(response);
            }
