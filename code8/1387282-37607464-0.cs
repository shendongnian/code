        public JsonResult   GetDataBehzad()
        {
            List<int> list = new List<int>();
            list.Add(10);
            list.Add(100); 
            return Json(list, JsonRequestBehavior.AllowGet); 
        }
 
