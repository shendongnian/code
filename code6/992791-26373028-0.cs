    private ConnectContext db = new ConnectContext();
    
    public ActionResult Index()
       {
         return View(db.Tv.ToList());
       }
