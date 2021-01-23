    [HttpPost]
    public ActionResult Index(ContactForm contact)
    {
       if(ModelState.IsValid)
       {
          // to do : Save and redirect
       }
       ViewBag.ValidationFailed="Yes";
       return View("Index",contact);
    }
