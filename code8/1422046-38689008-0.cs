    public ActionResult Index()
    {
       var userId=User.Identity.GetUserId();
    
       if(!User.Identity.IsAuthenticated)  return RedirectToAction("Login", "Account");
    
      var myNotif = db.Notifications
                  .Where(s => s.User1_Id == userId || s.User2_Id == userId )
                  .Where(s => s.Active_Status != userId).ToList();
      ViewBag.Autobots = new NotificationStatus[myNotif.Count()];
      int i = 0;
      foreach(var item in myNotif)
        {
           var user=db.Users.FirstOrDefault(x=>x.Id==item.Active_Status);
           ViewBag.Autobots[i].name = user.FirstName + " " + user.LastName;
            i++;
        }
       return View(myNotif.ToList());
    }
