    public async Task<string> GetRequest(string url) {
        Uri getUri = new Uri("http://172.20.129.193/nypstudentlifeservice/" + url);
        HttpClient client = new HttpClient();
        HttpResponseMessage responseGet = await client.GetAsync(getUri);
        responseGet.EnsureSuccessStatusCode(); // Throw if not a success code.
        string content = await responseGet.Content.ReadAsStringAsync();
        return content;
    }
    public async Task<IEnumerable<CsClubList>> getClubList() {
        string json = await GetRequest("api/club/list?categoryid=2");
    
        List<CsClubList> clublist = JsonConvert.DeserializeObject<List<CsClubList>>(json);
    
        return clublist;
    }
