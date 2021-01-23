    public ActionResult Index(DateTime? date)
    {
       YourViewModel vm = new ViewModel();
       if(date!=null)
       {
         //Do your filtering based on the date.Value.
       }
       return View(vm);
    }
