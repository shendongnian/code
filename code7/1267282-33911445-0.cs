    [HttpPost]
    public JsonResult Index()
    {
        JsonResult result = new JsonResult();
    
        foreach (HttpPostedFileBase file in Request.Files)
        {
            ...
        }
    
        return result;
    }
