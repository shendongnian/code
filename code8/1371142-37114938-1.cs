    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(UserProfileViewModel userViewModel)
      {
        if (ModelState.IsValid)
        {
          HttpPostedFileBase fileUploadObj= Request.Files[0];
          //for collection
          HttpFileCollectionBase fileUploadObj= Request.Files;
        ....
       }
       return View(userViewModel);
      }
    
