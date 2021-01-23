        public async Task<string> Post<T>(string path, T data)
        {
            using (var client = new HttpClient())
            {
                client.Timeout = new TimeSpan(0, 0, 5);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var json = JsonConvert.SerializeObject(data);
                var response_message = await client.PostAsync(local_host_address + path, new StringContent(json, Encoding.UTF8, "application/json");
                var response = await response_message.Content.ReadAsStringAsync();
                if (response_message.IsSuccessStatusCode)
                {
                    return response;
                }
                else
                {
                    throw new Exception("Request failed");
                }
            }
        }
