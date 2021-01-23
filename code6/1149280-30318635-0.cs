    //Get the json
    private JsonResult GetJsonResult()
    {
        //whatever json you are expecting on api side
        return Json(new { Number = "Num", type = "getalldetails" });
    }
    private void Update()
    {
        var URI = new Uri("http://hostname/api/controller/GetDetails");
        //serialize json object to string, .Data just to get json data
        string jsonText = JsonConvert.SerializeObject(GetJsonResult().Data);
        //post to api
        using (var client = new WebClient())
        {
            client.Encoding = Encoding.UTF8;
            client.Headers.Add("Content-Type", "text/json");
            client.UploadString(URI, "POST", jsonText);
        }
    }
