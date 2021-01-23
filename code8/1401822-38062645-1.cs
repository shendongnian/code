    [HttpPost]
    public ActionResult SignIn(string username, string password)
    {
          // Compare your password
          if(password == yourSpecialPassword)
          {
              return RedirectToAction("Index", "Buys");
          }
          // If you are still around, authenticate the user here
    }
