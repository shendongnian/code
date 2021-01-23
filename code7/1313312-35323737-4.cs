    public async Task<ClassifiersResponse> GetClassifiersAsync()
    {
        ClassifiersResponse model = null;
        using (var client = VrClient())
        {
            try
            {
                var response = await client.GetAsync("api/v2/classifiers?version=" + VersionReleaseDate);
                var msg = string.Format("{0} {1}", response.StatusCode, response.ReasonPhrase);
                Console.WriteLine(msg);
                if (response.IsSuccessStatusCode)
                {
                    model = await response.Content.ReadAsAsync<ClassifiersResponse>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
        return model;
    }
