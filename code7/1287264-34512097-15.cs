    public ActionResult getOnlineTestTitle()
    {
    var connectionString = WebConfigurationManager.ConnectionStrings["liveData"].ConnectionString;
        List<GopreadyOnlineTest> search = Session["OnlineTest"] as List<GopreadyOnlineTest> 
                                          ?? GopreadyOnlineTest.Search(connectionString).ToList();
    
        Session["OnlineTest"] = search;
    
        var result = search.GroupBy(x => x.CategoryName)
                           .Select(c => new SampleViewModel 
                                        { 
                                            Category = c.Key, 
                                            SubCategories = c.Select(sc => sc.SubCategoryName).Distinct().ToList() 
                                        });
        return Json(result, JsonRequestBehavior.AllowGet);            
    }
