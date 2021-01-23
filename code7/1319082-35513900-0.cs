    [WebMethod]
    public static string checkQuery(string sql)
    {
        string encryptingIT = new AES().Encrypt(sql);
        var client = new RestClient("http://dev-zzzz/newWS");
        var request = new RestRequest("theQ/", Method.POST);
            
        request.RequestFormat = DataFormat.Json;
        request.AddBody(new Product
        {
            query = encryptingIT,
            empImg = false
        });
        IRestResponse response = client.Execute(request);
        var content = response.Content;
        return content;
    }
