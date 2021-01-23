    [HttpGet]
        public JsonResult GetPageFilters()
        {
            ...
            ...
    
            if (settings != null)
            {
                var data = JsonConvert.DeserializeObject(settings.Filters); //Filter is string with json
    
                return Json(data, JsonRequestBehavior.AllowGet);  
            }
            else
            {
                return Json(null, JsonRequestBehavior.AllowGet);  
            }            
        }
