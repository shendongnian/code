    [HttpGet]
    public ActionResult UserOptions(User user)
    {
      if (!ModelState.IsValid)
      {
        // Build select lists again
        return View(user)
      }
      UserRepository.SaveOptions(user) // Save options to database
      // Redirect to the user details page?
      return RedirectToAction("Details", new { ID = user.ID })
    }
