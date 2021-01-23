    struct VersionInfo
    {
        public string name;
        public string value;
    }
    
    static void JsonExample()
    {
        // create a dictionary as example
        var dict = new Dictionary<string, VersionInfo[]>();
        dict.Add("android", new VersionInfo[3]);
        dict["android"][0] = new VersionInfo { name = "aaa", value = "123" };
        dict["android"][1] = new VersionInfo { name = "bb", value = "34" };
        dict["android"][2] = new VersionInfo { name = "cc", value = "56" };
    
        var result = Newtonsoft.Json.JsonConvert.SerializeObject(dict);
    }
