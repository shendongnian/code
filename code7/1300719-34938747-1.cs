    public ActionResult ConfirmPayment()
    {
      PayNowViewModel model = new PayNowViewModel();
      ConfigureViewModel(model);
      return View(model);
    }
