    public JsonResult GetModels(string brandID="")
    {
        List<Model> models = new List<Model>();
        int ID = 0;
        if (int.TryParse(brandID, out ID))
        {
            using (CarsEntities1 dc = new CarsEntities1())
            {
               models = dc.Models.Where(a => a.Brand_ID == ID).OrderBy(a =>a.Model_name);
               if (Request.IsAjaxRequest())
               {
                  return new JsonResult
                  {
                        Data = models.ToList(),
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                  };
               }  
            }
        }              
        return new JsonResult
        {
            Data = "Not valid request",
            JsonRequestBehavior = JsonRequestBehavior.AllowGet
        };    
    }
