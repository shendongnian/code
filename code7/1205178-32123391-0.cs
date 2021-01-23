        public static sReturn = "";
        public async Task _InetReadEx(string sUrl)
            {
                try
                {
                    HttpClient httpClient = new HttpClient();
    
                    HttpResponseMessage response = await httpClient.GetAsync(new Uri(sUrl));
                    response.EnsureSuccessStatusCode();
    
                    //sStatus = response.StatusCode + " " + response.ReasonPhrase + Environment.NewLine;
                    sSource = await response.Content.ReadAsStringAsync();
                    sSource = sSource.Replace("<br>", Environment.NewLine); // Insert new lines
                }
                catch (Exception hre)
                {
                    sSource = string.Empty;
                }
            }
