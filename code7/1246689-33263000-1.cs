    public ActionResult AutoComplete(string term, string SearchBy)
    {
        if (SearchBy == "Tag")
        {
            var tech = repository.AllFindTechnolog(term.Trim()).ToList();
            var resources = repository.GetResources(tech.Select(a => a.IT360ID.Value).ToArray(), 
                                                    false).ToList();
            var query = from techItems in tech
                        join resourcesItems in resources
                        on techItems.IT360ID.Value equals resourcesItems.RESOURCEID
                        orderby techItems.PartialTag
                        select new AutoCompleteViewModel { extra = true, 
                                                           label = techItems.Tag.ToString(), 
                                                    techtype = techItems.TechnologyType.Name, 
                                          status = resourcesItems.ResourceState.DISPLAYSTATE, 
     customername = resourcesItems.ResourceLocation.SiteDefinition.AccountDefinition.ORG_NAME.ToString(), resourcename = resourcesItems.RESOURCENAME.ToString(), sitename = resourcesItems.ResourceLocation.SiteDefinition.SDOrganization.NAME };
        return Json(query, JsonRequestBehavior.AllowGet);
    }
    else
    {
        var activeResources = repository.FindActiveResourceByName(term.Trim(), true).ToList();//.OrderBy(p => p.RESOURCENAME).Select(a => new { label = a.RESOURCENAME }).ToList();
        var resources = repository.GetResources(activeResources.Select(a => a.RESOURCEID).ToArray(), false).ToList();
        var tech = repository.getTechnologiesByIT360ids(activeResources.Select(a=>a.RESOURCEID).ToArray()).ToList();
        var query = from techItems in tech
                    join resourcesItems in resources
                    on techItems.IT360ID.Value equals resourcesItems.RESOURCEID // join based on db2ID
                    orderby techItems.Tag
                    select new AutoCompleteViewModel { extra = true, label = resourcesItems.RESOURCENAME.ToString(), techtype = techItems.TechnologyType.Name, status = resourcesItems.ResourceState.DISPLAYSTATE, customername = resourcesItems.ResourceLocation.SiteDefinition.AccountDefinition.ORG_NAME.ToString(), resourcename = techItems.Tag.ToString(), sitename = resourcesItems.ResourceLocation.SiteDefinition.SDOrganization.NAME };
            return Json(query, JsonRequestBehavior.AllowGet);
        }
    }
