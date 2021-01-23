     public static async Task<int> HtmlLoadAsync(string url/*, bool addUserAgent = false*/)
        {
            try
            {
                var client = new HttpClient();
                //if (addUserAgent)                 OPTIONAL 
                //{
                //    client.DefaultRequestHeaders.UserAgent.ParseAdd(UserAgent);
                //}
                //client.Timeout = TimeOut;
                var response = client.GetStringAsync(url);
                var urlContents = await response;
                var document = new HtmlAgilityPack.HtmlDocument();
                document.LoadHtml(urlContents);
                // process document now
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return 0;
        }
