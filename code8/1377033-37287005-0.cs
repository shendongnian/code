    public ActionResult Index() {
        OurDBContext db = new OurDBContext();
        return View(db.car.ToList());
    }
    
