    public ActionResult NewGame()
    {
        var game = new Game();
        Session["game"] = game;
        return View(game);
    }
    public ActionResult Cheat()
    {
        if (Session["game"] == null)
        {
            return RedirectToAction("NewGame");
        }
        var game = Session["game"] as Game;
        return View(game);
    }
