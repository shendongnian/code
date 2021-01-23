        public async Task<TResult> InvokeClientGet<TResult>(string relativeUri)
        {
            try
            {
                using (var client = new HttpClient { BaseAddress = _serviceBaseAddress })
                {
                    using (var response = await client.GetAsync(relativeUri))
                    {
                        if (response.StatusCode == HttpStatusCode.NotFound || 
                            !response.IsSuccessStatusCode)
                        {
                            return default(TResult);
                        }
        
                        return await response.Content.ReadAsAsync<TResult>();
                }
            }
            catch (Exception ex)
            {
                // Handle exceptional conditions
            }
        }
