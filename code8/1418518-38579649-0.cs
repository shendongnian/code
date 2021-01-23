    public ActionResult Dispatch()
            {
                db.Dispatches.Include("Customer").ToList();
                db.Dispatches.Include("Recipient").ToList();
                var dispatch = db.Dispatches;
    
                return View(dispatch);
            }
