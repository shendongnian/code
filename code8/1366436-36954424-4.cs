    public ActionResult Login(){
                if (globalTicketVariable != null && globalTicketVariable != "")
                {
                        DataContext Context = new DataContext();
                        User TempUser = Context.User.Where(x => x.UserID == (int)globalTicketVariable).FirstOrDefault();
                        if (TempUser != null)
                        {
                            return RedirectToAction("Success", "SuccessPage");
                        }
                }
                return View();
    }
