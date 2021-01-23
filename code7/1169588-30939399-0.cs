    public ActionResult SomeAction()
    {
        return RedirectToAction("Widgets", "SomeOtherAction", new { something = somevalue });
    }
    public ActionResult SomeOtherAction()
    {
        return View();
    }
