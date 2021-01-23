    [HttpGet]
    public ActionResult UserOptions(int ID)
    {
      User user = UserRepository.Get(ID); // get user and user options from database
      ViewBag.AbsolutePressOptions = new SelectList(....
      return View(user);
    }
