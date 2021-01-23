      public static async Task<List<string>> GetStreamsFromPLSUrl(string url)
        {
            var httpClientHandler = new HttpClientHandler { UseDefaultCredentials = false, AllowAutoRedirect = true };
            HttpClient httpClient = new HttpClient();
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                TextReader tr = new StreamReader(await response.Content.ReadAsStreamAsync());
                List<string> Streamurls = new List<string>();
                string line;
                while ((line = tr.ReadLine()) != null)
                {
                    if (line.Substring(0, 4).Equals("File"))
                        Streamurls.Add(line);
                }
                return (Streamurls);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message + "/n" + ex.InnerException);
                return null;
            }
        }
