    StreamReader s= new StreamReader(@"test.txt");
    string json = s.ReadToEnd();
    json=json.Replace("\\","\\\\");
    JObject obj = JObject.Parse(json);
    string pattern = obj["Pattern"].ToString();
    bool test = Regex.IsMatch("1	a", pattern);
