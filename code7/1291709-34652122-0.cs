    public JsonResult GetModels(int brandID)
    {
     String[] models;
    using (CarsEntities1 dc = new CarsEntities1())
    {
       models = dc.Models.Where(a => a.Brand_ID == brandID).Select(a=> a.Model_name).toArray();
       if (Request.IsAjaxRequest())
       {
           return new JsonResult
           {
                Data = models,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
           };
        }  
    }
    return new JsonResult
    {
        Data = "Not valid request",
        JsonRequestBehavior = JsonRequestBehavior.AllowGet
    };    
    }
