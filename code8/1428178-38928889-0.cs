    String item1 = "£";
    String item2 = "&";
    String item3 = "xyz";
    
    Dictionary<string,string> queryDictionary = new Dictionary<string, string>()
    {
        {"item1", item1},
        {"item2", item2},
        {"item3", item3}
    };
    
    var queryString = new System.Net.Http.FormUrlEncodedContent(queryDictionary)
            .ReadAsStringAsync().Result;
