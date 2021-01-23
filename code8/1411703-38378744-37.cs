    public ActionResult Get()
    {
        string data = myclient.DownloadString("URL");
        List<Codes> myobj = (List<Codes>)JsonConvert.DeserializeObject(data, typeof(List<Codes>));
        // Let's convert it into what you want.
        var text = string.Join(",", list.Select(x => string.Format("[{0},{1}]", x.hr, x.ps)));
        return this.Content(text);
    }
