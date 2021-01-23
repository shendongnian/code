    [WebMethod]
    [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
    public void GetMaps(string mapId)
    {
        DataTable dt = new DataTable();
       dt = dataClass.data.get(mapId);
        string jsonString = string.Empty;
        jsonString = JsonConvert.SerializeObject(dt);
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";
        Context.Response.Flush();
        Context.Response.Write(jsonString);
    }
