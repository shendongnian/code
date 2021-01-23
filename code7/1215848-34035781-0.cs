      public static async Task<T> ExecuteGet<T, K>(string url, K obj) where T : class
        {
            if (String.IsNullOrWhiteSpace(url))
                return default(T);
            var client = new HttpClient();
            string str = JsonConvert.SerializeObject(obj);
            Debug.WriteLine("json Request :" + url + str);
            HttpResponseMessage response = await client.GetAsync(new Uri(url + str));
            if (response.IsSuccessStatusCode)
            {
                var ResponceString = await response.Content.ReadAsStringAsync();
                Debug.WriteLine("Json responce :" + ResponceString);
                var data = JsonConvert.DeserializeObject<T>(ResponceString);
              
                return (T)Convert.ChangeType(data, typeof(T));
            }
            else
            {
                return default(T);
            }
        }
