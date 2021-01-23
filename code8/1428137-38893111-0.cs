    public static string jsonconvert(string url)
    {
    string currentsite = HttpContext.Current.Request.Url.Authority;
    WebClient wc = new WebClient();
    wc.Encoding = Encoding.UTF8;
    wc.Encoding = UTF8Encoding.UTF8;
    string test = "http://" + currentsite + url;
    var data = wc.DownloadString(test);
    string jsonresult = "{\"results\":" + data.ToString() + "}";
    return jsonresult;
    }
    
    string jsonurl = "";
    string getjsonresult = "";
    
    getjsonresult = Jsonget.jsonconvert("http://localhost/returnData.php");
    Newtonsoft.Json.Linq.JObject Result= Newtonsoft.Json.Linq.JObject.Parse(getjsonresult);
    
    
    foreach (var get_result in Result["results"])
    {
    string id= (string)get_result ["id"];
    string name_id= (string)get_result ["name_id"];
    }
