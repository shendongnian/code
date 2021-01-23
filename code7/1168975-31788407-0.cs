    private string username = "user";
    private string password = "passkey";
    private string myUrl = "http://some_url.com/id?=20";
    private WebClient client = new WebClient();
    
    private void retrieveJson()
    {
            client.Credentials = new NetworkCredential(username, password);
            client.Encoding = Encoding.UTF8;
            client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(wc_DownloadStringCompleted);
            client.DownloadStringAsync(new Uri(myUrl), UriKind.Relative);
    }
    //WebClient String (json content) Download
    private void wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
    {
            // You will get you Json Data here..
            var myJSONData = e.Result;
            JObject JsonData = JObject.Parse(myJSONData);
            //Do something with json 
            //Ex: JsonData["Array1"][5]
    }
