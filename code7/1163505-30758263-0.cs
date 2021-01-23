    public override ActionResult Index(RenderModel model)
    {
        var entries = this.GetContestEntries(this.GetCountryFolder(CurrentPage.GetProperty("contestMediaFolder").Value.ToString()));
    
        return base.Index(model);
    }
    public DynamicPublishedContent GetCountryFolder(string countryFolder)
    {
        return (DynamicPublishedContent)Umbraco.Media(countryFolder);
    }
    public List<WAR2015ContestModel> GetContestEntries(DynamicPublishedContent countryFolder)
    {
         .....  // code omitted
    }
