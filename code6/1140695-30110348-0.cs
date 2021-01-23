    public class Result
    {
        public HttpStatusCode Status { get; set; }
        public string Data { get; set; }
    }
    
    public async Task<Result> LoginAsync(string user, string password)
    {
        var http = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Get, new Uri("http://*******/nl/webservice/abc123/members/login?email="+ user + "&password="+ password));
        var result = await http.SendRequestAsync(request);
    
        var data = new Result {Status = result.StatusCode};
        if (result.StatusCode== HttpStatusCode.Ok && result.Content!=null)
        {
            data.Data = await result.Content.ReadAsStringAsync();
        }
        return data;
    }
