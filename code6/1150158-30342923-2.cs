    public ActionResult _GetRegions()
    {
        List<SelectListItem> ddlItems = Global.GetRegionDropdownItems(
                                            ConfigurationManager.AppSettings["ApplicationId"],
                                            ref ErrorMessage);
        ViewBag.Regions = ddlItems;
    
        return PartialView();
    }
