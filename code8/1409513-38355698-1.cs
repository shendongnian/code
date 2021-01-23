        public async Task<IEnumerable<Availablity>> GetAvailabilityBySkuList(IEnumerable<string> skuList)
        {
            var output = JsonConvert.SerializeObject(skuList);
            HttpContent contentPost = new StringContent(output, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = _client.PostAsync("/api/availabilityBySkuList", contentPost).Result;
            if (response.IsSuccessStatusCode)
            {
                var avail = await response.Content.ReadAsStringAsync()
                    .ContinueWith<IEnumerable<Availablity>>(postTask =>
                    {
                        return JsonConvert.DeserializeObject<IEnumerable<Availablity>>(postTask.Result);
                    });
                return avail;
            }
            return null;
        }
