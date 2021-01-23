    [HttpGet]
    public JsonResult GetAllCECOS()
    {
        using (RPIEntities contextObj = new RPIEntities())
        {
            try
            {
                var listaCECOS = contextObj.T0CECOS.ToList();
                **return Json(listaCECOS, JsonRequestBehavior.AllowGet);**
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
