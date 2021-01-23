    private string username = "user";
    private string password = "passkey";
    private string myUrl = "http://some_url.com/id?=20";
    private WebClient client = new WebClient();
    private string parameters = "{\"I_NAME\":\"0000"\"}"; //Example
    private void postMethod()
    {
            client.Credentials = new NetworkCredential(username, password);
            client.Encoding = Encoding.UTF8;
            client.Headers["Content-Length"] = parameters.Length.ToString();
            client.UploadStringCompleted += new UploadStringCompletedEventHandler(client_UploadStringCompleted);
            client.UploadStringAsync(new Uri(myUrl), "POST", parameters);
    }
    private void client_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
    {
            if (e.Error == null)
            {
                var myJSONData = e.Result;
                JObject JsonData = JObject.Parse(myJSONData);
            }
    }
