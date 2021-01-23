    using (HttpClient client = new HttpClient())
    {
        using (HttpResponseMessage response = await client.GetAsync(uri, cancel))
        {
            using (Stream stream = response.Content.ReadAsStreamAsync().Result)
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    return new JsonSerializer().Deserialize<T>(new JsonTextReader(reader));
                }
            }
        }
    }
