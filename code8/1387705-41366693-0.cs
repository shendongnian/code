    public static void Main(string[] args)
    {
        Console.WriteLine(SendSimpleMessage().Content.ToString());
        Console.ReadLine();
    }
    
    public static IRestResponse SendSimpleMessage()
    {
        var path1 = @"C:\Users\User\Pictures\website preview";
        var fileName = "Learn.png";
        RestClient client = new RestClient();
        client.BaseUrl = new Uri("https://api.mailgun.net/v3");
        client.Authenticator =
            new HttpBasicAuthenticator("api",
                                        "key-934345306fead7de0296ec2fb96a143");
        RestRequest request = new RestRequest();
        request.AddParameter("domain", "mydomain.info", ParameterType.UrlSegment);
        request.Resource = "{domain}/messages";
        request.AddParameter("from", "Excited User <example@mydomain.info>");
        request.AddParameter("to", "peter.cech@gmail.com");        
        request.AddParameter("subject", "Hello");
        request.AddParameter("text", "Testing some Mailgun awesomness! This is all about the text only. Just testing the text of this email.";
        request.AddFile("attachment", Path.Combine(path1,fileName));
        request.Method = Method.POST;
        return client.Execute(request);
    }
