    [ChildActionOnly]
    public ActionResult SideBar()
    {
      var role = ... // your code for getting the users role
      if (role == "Admin")
      {
        return PartialView("_AdminSideBar");
      }
      else if (role == "Faculty")
      {
        return PartialView("_FacultySideBar");
      }
      else if ..........
    }
