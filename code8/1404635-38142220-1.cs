    public ActionResult Test()
    {
        using (var repository = new UserRepository())
        {
             var user = repository.Find(User.Identity.GetUserId());
             user.FirstName = "BLAH BLAH";
             repository.Update(user);
        }
        return RedirectToAction("Index");
    }
