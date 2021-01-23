    // local time -- default datetime handling from JSON.NET
    {
        var dateTime = DateTime.Now;
        var jsonObject = new JObject {["dateTime"] = dateTime};
        var jsonString = jsonObject.ToString();
        Debug.WriteLine(jsonString); // uses "2015-10-19T18:13:53.4698565-04:00" form
    }
    // UTC time -- default datetime handling from JSON.NET
    {
        var dateTime = DateTime.Now.ToUniversalTime();
        var jsonObject = new JObject {["dateTime"] = dateTime };
        var jsonString = jsonObject.ToString();
        Debug.WriteLine(jsonString); // uses "2015-10-19T22:13:53.5166571Z" form
    }
    // local time -- Microsoft-like datetime handling from JSON.NET
    {
        var dateTime = DateTime.Now;
        var jsonObject = new JObject {["dateTime"] = dateTime };
        var jsonString = JsonConvert.SerializeObject(jsonObject, new JsonSerializerSettings { DateFormatHandling = DateFormatHandling.MicrosoftDateFormat });
        Debug.WriteLine(jsonString); // uses "/Date(1445292833516-0400)/" format
    }
    // local time -- Microsoft-like datetime handling from JSON.NET
    {
        var dateTime = DateTime.Now.ToUniversalTime();
        var jsonObject = new JObject {["dateTime"] = dateTime };
        var jsonString = JsonConvert.SerializeObject(jsonObject, new JsonSerializerSettings { DateFormatHandling = DateFormatHandling.MicrosoftDateFormat });
        Debug.WriteLine(jsonString); // uses "/Date(1445292833579)/" form
    }
