      using System.Web.Script.Serialization;
   
      [HttpGet]
            public JsonResult  Get(int id)
            {
                var ListOfMyObject = db.TESTS.ToList(); 
                JavaScriptSerializer jss = new JavaScriptSerializer();
        
                string output = jss.Serialize(ListOfMyObject);
                return Json(output , JsonRequestBehavior.AllowGet);  
            }
