    public async virtual Task<string> ExecuteHttpApiCall<TModel>(TModel model, string url)
            {
                HttpResponseMessage response;
                using (var client = new HttpClient())
                {
                    if (model != null)
                    {
                        response = await client.PostAsJsonAsync(url, model);
                    }
                    else
                    {
                        response = await client.GetAsync(url);
                    }
    
                    return await response.Content.ReadAsStringAsync();
                }
            }
