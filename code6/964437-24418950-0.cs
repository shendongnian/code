    class MyController : Controller {
      //...
      private static object userlock = new object();
      //...
      ActionResult CheckUser() {
        string username =  User.Identity.Name.Replace(@"MyDomain\", "");
        lock(userlock) 
        {
          var user = db.UserBases.Where(x => x.UserName == username).Select(c => c.UserName).FirstOrDefault();
    
          if(user == null)
          {
            //insert user into db ...
          } //if (user ==null)
        } //lock (userlock)
        //...
      } //CheckUser()
    }  //MyController
