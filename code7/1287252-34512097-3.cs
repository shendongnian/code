    [HttpGet]
    public JsonResult GetOnlineTestTitle()
    {               
        var result = search.GroupBy(x => x.CategoryName)
                           .Select(c => new SampleViewModel 
                                        { 
                                            Category = c.Key, 
                                            SubCategories = c.Select(sc => sc.SubCategoryName).ToList() 
                                        });
        return Json(result, JsonRequestBehavior.AllowGet);
    }
