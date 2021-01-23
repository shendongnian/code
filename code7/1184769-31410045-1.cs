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
            var response = client.GetStringAsync(url); //here you can change client method according to your required outpu
            var urlContents = await response;            
            // process urlContents now
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return 0;
    }
