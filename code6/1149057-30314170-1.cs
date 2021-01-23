    public async Task<IHttpActionResult> Get()
    {
        List<PersonModel> people = new List<PersonModel>
        {
            new PersonModel
            {
                FirstName = "Test",
                LastName = "One",
                Age = 25
            },
            new PersonModel
            {
                FirstName = "Test",
                LastName = "Two",
                Age = 45
            }
        };
        using (HttpClientHandler handler = new HttpClientHandler())
        {
            handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            using (HttpClient client = new HttpClient(handler, false))
            {
                string json = JsonConvert.SerializeObject(people);
                byte[] jsonBytes = Encoding.UTF8.GetBytes(json);
                MemoryStream ms = new MemoryStream();
                using (GZipStream gzip = new GZipStream(ms, CompressionMode.Compress, true))
                {
                    gzip.Write(jsonBytes, 0, jsonBytes.Length);
                }
                ms.Position = 0;
                StreamContent content = new StreamContent(ms);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                content.Headers.ContentEncoding.Add("gzip");
                HttpResponseMessage response = await client.PostAsync("http://localhost:54425/api/Gzipping", content);
                IEnumerable<PersonModel> results = await response.Content.ReadAsAsync<IEnumerable<PersonModel>>();
                Debug.WriteLine(String.Join(", ", results));
            }
        }
        return Ok();
    }
