    public async Task UploadExceptionReport(String s)
    {
        using (var client = new HttpClient())
        {
            var uri = new Uri(Program.ServerUri + "api/exception_report");
            var content = new FormUrlEncodedContent(new[]
            {
                 new KeyValuePair<string, string>("exception_string", s)
            });
            var result = await client.PostAsync(uri, content);
            string resultContent = await result.Content.ReadAsStringAsync();
            Console.WriteLine(resultContent);
        }
	}
