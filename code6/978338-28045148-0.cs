    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    //...
    protected override void OnResume()
    {
    var request = HttpWebRequest.Create("Your_URL_XXX");
    request.ContentType = "application/json";
    request.Method = "POST";
    
    
    var clientRequest = new ResourceByNameRequest
    {
        Name = "G60",
        UserId = "1"
    };
    using (var writer = new StreamWriter(request.GetRequestStream()))
    {
        writer.Write(clientRequest.ToString());
    }
    try
    {
        using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
    {
    string error = "";
    if (response.StatusCode != HttpStatusCode.OK)
    error = string.Format("Error fetching data. Server returned status code: {0} | Description: {1}", response.StatusCode, response.StatusDescription);
    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
    {
        var content = reader.ReadToEnd();
        if (string.IsNullOrWhiteSpace(content))
        {
            strResponse = "Response contained empty body...";
        }
        else
        {
            var cont = JObject.Parse(content);
            YOUR_OBJECT_RESPONSE.PROP1 = cont["Prop1"].NullSafeToString();
            YOUR_OBJECT_RESPONSE.PROP2 = cont["Prop2"].NullSafeToString();
            //...
    
        }
    }
    }
    } 
        catch (WebException wex)
        {
        var pageContent = new   StreamReader(wex.Response.GetResponseStream()).ReadToEnd();   
        }
    }
