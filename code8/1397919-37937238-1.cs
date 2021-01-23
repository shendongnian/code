        static void Main()
        {
            Test().GetAwaiter().GetResult();
        }
        private static async Task Test()
        {
            const string url = "http://google.com";
            const int bytesToRead = 2000;
            using (var httpclient = new HttpClient())
            {
                httpclient.DefaultRequestHeaders.Range = new RangeHeaderValue(0, bytesToRead);
                var response = await httpclient.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
                using (var stream = await response.Content.ReadAsStreamAsync())
                {
                    var buffer = new byte[bytesToRead];
                    stream.Read(buffer, 0, buffer.Length);
                    var partialHtml = Encoding.UTF8.GetString(buffer);
                    //extract required info from partial html
                }
            }
        }
