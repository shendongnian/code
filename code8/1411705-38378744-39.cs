    public ActionResult Get()
    {
        string data = myclient.DownloadString("URL");
        List<Codes> myobj = (List<Codes>)JsonConvert.DeserializeObject(data, typeof(List<Codes>));
        return new CodesResult(myobj);
    }
