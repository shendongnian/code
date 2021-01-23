    using System.Web.Script.Serialization;
    using System.Net;
    using (var client = new WebClient())
    {
        var url = "http://nerdcastlebd.com/web_service/voterdb/index.php/voters/all/format/json";
        var jsonString = client.DownloadString(url);
        var json = new JavaScriptSerializer().Deserialize<dynamic>(jsonString);
        foreach (Dictionary<string, object> voter in json["voters"])
        {
            var id = voter["id"].ToString();
            // pull name, address and date_of_birth here
        }
    }
