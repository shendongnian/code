      public JsonResult GetResourceString(string labelName)
        {
            string result ="";
            result = ResourceMessage.ResourceManager.GetString(labelName);
            if (Request.Cookies["culture"].Value == "th")
            {
                cul = CultureInfo.CreateSpecificCulture("th"); 
                 result = ResourceMessage.ResourceManager.GetString(labelName,cul);
            }
            return Json(new
            {
                message = result
            }, JsonRequestBehavior.AllowGet);
        }
