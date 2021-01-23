    async Task RunAsync()
    {
        using (var client = new HttpClient())
        {
            string baseAddress =
            "http://74.120.219.166/Services/OnyxCloudSyncService.svc/pingSync";
            client.BaseAddress = new Uri(baseAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new
               MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await
                       client.GetAsync("?sampleJson={SAMPLEJSON}");
            if (response.IsSuccessStatusCode)
            {
                string txtBlock = await response.Content.ReadAsStringAsync();
                Response.Write(txtBlock);
                Response.End();
            }
            else
            {
                Response.Write("Error Calling service");
                Response.End();
            }
        }
    }
