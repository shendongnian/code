    public async Task<string> MakeWebRequest()
    {
        HttpClient http = new HttpClient();
        HttpResponseMessage response = await http.GetAsync(**URL**);
    
        var str = await response.Content.ReadAsStringAsync();
        var bytes = Encoding.Default.GetBytes(str);
        str = Encoding.UTF8.GetString(bytes);
        return str;
    }
