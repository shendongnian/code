      public JsonResult GetUsers(string term, int otherId)
      {
          Context db = new Context();
          List<string> users;
    
    	  if(otherId == ???)
    	  // Default search
    	  else
    	  // Search alternate location
    
         .
         .
         .
          return Json(users, JsonRequestBehavior.AllowGet);
      }
