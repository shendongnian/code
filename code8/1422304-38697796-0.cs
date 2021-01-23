    using Newtonsoft.Json.Linq;
    
    public void MakeStrings(string json)
    {
        var jobject = JsonConvert.DeserializeObject<JObject>(json);
        string acl_gent = JsonConvert.SerializeObject(jobject["acl_gent"]);
        string acl_luik = JsonConvert.SerializeObject(jobject["acl_luik"]);
    }
