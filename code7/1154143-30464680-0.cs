    public ActionResult Stores(int StoreID){
             var query = (from s in db.tStores
                         where s.StoreID == StoreID
                         select s).ToList();
                         ViewBag.query = query;
                         return RedirectToAction("Index","Index");
    }
