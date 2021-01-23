     public JsonResult AutoCompleteCity(string term)
            {
                List<City> listData = new List<City>();
                if (!string.IsNullOrEmpty(term))
                {
                    listData = db.AutoCompleteCity(term);
                }
    
                return Json(listData, JsonRequestBehavior.AllowGet);
    
            }
 
