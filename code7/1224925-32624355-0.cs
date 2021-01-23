    private void AddWebPartToPage(SPWeb web, string filepath, string zoneidname, int zoneIndex)
        {
            SPLimitedWebPartManager wpm = web.GetLimitedWebPartManager(filepath, System.Web.UI.WebControls.WebParts.PersonalizationScope.Shared);
            wpm.AddWebPart(wp, zoneidname, zoneIndex);
        }
    AddWebPartToPage(web, web.Url + "SitePages/Home.aspx", "CentreLeft", 0);
