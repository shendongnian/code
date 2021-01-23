            var obj = new MyClass()
            {
                MyProperty = 11
            };
            using (var client = new HttpClient())
            {
                string inputJson = Newtonsoft.Json.JsonConvert.SerializeObject(obj); 
                HttpContent inputContent = new StringContent(inputJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response1 = client.PostAsync("http://localhost:60909/api/home/Test", inputContent).Result;
                if (response1.IsSuccessStatusCode)
                {
                }
            }
