    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult UserProfileViewModel(UserProfileViewModel userViewModel)
    {
    if (ModelState.IsValid)
    {
      HttpPostedFileBase fileUpload= Request.Files[0];
      //for collection
      HttpFileCollectionBase fileUpload= Request.Files;
     ....
     }
