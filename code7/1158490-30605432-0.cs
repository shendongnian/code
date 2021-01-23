    [Httppost]
    public ActionResult YouAction(myVm  mymodel)
    {
        if (!ModelState.IsValid)
        {
           // fill your Viewbags 
           return View(mymodel);
        }
    }
