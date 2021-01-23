    private async Task<string> TryDownloadResourceAsync(string resourceId)
    {
      ResourceAccountListInfo resourceAccountListInfo = new ResourceAccountListInfo();
      using (WebClient wc = new WebClient()) 
      {
        string url = currentURL + "resources/" + resourceId + "/accounts?AUTHTOKEN=" + pmtoken;
        string tempurl = url.Trim();
        var json =  await wc.DownloadStringTaskAsync(tempurl);
        resourceAccountListInfo = JsonConvert.DeserializeObject<ResourceAccountListInfo>(json);
      }
      if (resourceAccountListInfo.operation.Details.CUSTOMFIELD.Count > 0)
      {
        List<CUSTOMFIELD> customfield = resourceAccountListInfo.operation.Details.CUSTOMFIELD.Where(a =>
            a.CUSTOMFIELDLABEL.ToLower() == "name"
        ).ToList();
        if (customfield.Count == 1)
        {
          return resourceAccountListInfo.operation.Details;
        }
      }
      return null;
    }
    public async Task <List<Details2>> Get()
    {       
      try
      {
        using (WebClient wc = new WebClient()) 
        {
          string url = currentURL + "resources?AUTHTOKEN=" + pmtoken;
          var json = await wc.DownloadStringTaskAsync(url);
          resourcesinfo = JsonConvert.DeserializeObject<ResourcesInfo>(json);
        }
        var tasks = resourcesinfo.operation.Details.Select(c => TryDownloadResourceAsync(c.RESOURCEID)).ToList();
        var results = await Task.WhenAll(tasks).Select(x => x != null);
        return results.ToList();
      }
      catch (Exception e)
      {
      }
      return new List<Details2>(); // Please, please don't do this in production.
    }
