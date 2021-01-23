    [HttpPost]
    public ActionResult Login(User user)
    {       
       try
       {
         var bl=new UserBusinessLogic();
         var result = bl.CheckUserLogin(user);
         //based on the result return something
         if(result==1) //demo purpose. Change to match with what your code actually returns
         {
            return Json(new {Status="Success" });
         }
         return Json(new {Status==="Invalid", Message="Invalid user credentials" });
      }
      catch(Exception ex)
      {
          return Json(new {Status==="Valid", Message="Code crashed!.
                       Put a breakpoint in your action method and see what is happening" });
      }
    }
