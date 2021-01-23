    public JsonResult create(MyModel.New details)
        {
            try
            {
                Library.insert(details);
                return Json(true); 
            }
            catch (Exception ex)
            {
                return Json(ex.Message); 
            }
        }
