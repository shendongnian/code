      public JsonResult GetUsers(string term)
      {
          Context db = new Context();
          List<string> users;
    
    	  if(term == ???)
    	  // Default search
    	  else
    	  // Search alternate location
    
         .
         .
         .
          return Json(users, JsonRequestBehavior.AllowGet);
      }
