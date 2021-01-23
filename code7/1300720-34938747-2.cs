    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult ConfirmPayment(PayNowViewModel model)
    {
      if (!ModelState.IsValid)
      {
        ConfigureViewModel(model);
        return View(model);
      }
      .... // save and redirect (should not be returning the view here)
    }
