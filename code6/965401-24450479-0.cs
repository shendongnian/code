    HttpCookie cookie = Request.Cookies.Get("wishlist");
    string JSONstring = string.Empty;
    string nodeId = string.Empty;
    string test = string.Empty;
    if (cookie != null)
    {
        JSONstring = cookie.Value;
        JObject obj = JObject.Parse(JSONstring);
        JArray packages = (JArray)obj["package"];
        
        foreach (var item in packages.Children()){
            var properties = item.Children<JProperty>();
            var idElement = properties.FirstOrDefault(x => x.Name == "id");
            var myElementValue = idElement.Value;
            test = test + myElementValue + ",";
        }
    }
