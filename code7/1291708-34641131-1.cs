    public JsonResult GetModels(int brandID)
    {
        List<Model> models = new List<Model>();
        using (CarsEntities1 dc = new CarsEntities1())
        {
           models = dc.Models.Where(a => a.Brand_ID == brandID).OrderBy(a =>a.Model_name);
           if (Request.IsAjaxRequest())
           {
               return new JsonResult
               {
                    Data = models.ToList(),
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
