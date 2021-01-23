        public async Task<IEnumerable<SkuGcn>> GetSkuGcnList()
        {
            HttpResponseMessage response = _client.GetAsync("/api/skuGcnList").Result;
            if (response.IsSuccessStatusCode)
            {
                var skuGcns = await response.Content.ReadAsStringAsync()
                    .ContinueWith<IEnumerable<SkuGcn>>(getTask =>
                    {
                        return JsonConvert.DeserializeObject<IEnumerable<SkuGcn>>(getTask.Result);
                    });
                return skuGcns;
            }
            return null;
        }
