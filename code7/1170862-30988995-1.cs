    if (requestModel != null && requestModel.Response != null)
    {
        PSObject responseObject = new PSObject();
        responseObject.Members.Add(new PSNoteProperty("SiteID", requestModel.Response.SiteID));
        responseObject.Members.Add(new PSNoteProperty("Identity", requestModel.Response.SiteName));
        // and so on etc... 
        responseObject.Members.Add(new PSNoteProperty("Latitude", requestModel.Response.latitude));
    
        this.WriteObject(responseObject);
    }
