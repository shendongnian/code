    [HttpPost]
    public ActionResult teamLookUp(string ID)
    {
        HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create("https://na.api.pvp.net/api/lol/na/v2.3/team/" + ID + "?api_key=myKey");
        myReq.ContentType = "application/json";
        var response = (HttpWebResponse)myReq.GetResponse();
        string text;
        using (var sr = new StreamReader(response.GetResponseStream()))
        {
            text = sr.ReadToEnd();
        }
        return Json(new { json = text }); // HERE'S THE ERRING LINE
    }
