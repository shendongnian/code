    public ActionResult Test(string model)
    {
      Request.InputStream.Seek(0, SeekOrigin.Begin);
      string jsonData = new StreamReader(Request.InputStream).ReadToEnd();
      var dynamicObject = JObject.Parse(jsonData);
      ...
    }
