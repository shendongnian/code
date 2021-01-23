    [HttpPost]
    public ActionResult Index(ContactForm contact)
    {
       if(ModelState.IsValid)
       {
          // to do : Save and redirect
       }
       ViewBag.ValidationFailed="Yes"; // flag to handle the client side scroll !
       return View("Index",contact);
    }
