    public ActionResult Play()
    {
      Game model = new Game();
      return View(model);
    }
    [HttpPost]
    public ActionResult Play(Game model)
    {
      if (!ModelState.IsValid)
      {
        return View(model);
      }
      return RedirectToAction("Result", new { userChoice = model.UserGuess });
    }
    public ActionResult Result(string userChoice)
    {
      Game model = new Game() { UsersGuess = userChoice };
      if (!model.Options.Contains(userChoice))
      {
        return new HttpResponseMessage(HttpStatusCode.BadRequest, "Your error message here");
      }
      model.Play();
      return View(model);
    }
