    public ActionResult Create(Expense ex)
    {
        if(ModelState.IsValid)
        {
            ex.expenseID = db.Expenses.Max( x => x.expenseID) + 1 ; 
            db.Expenses.Add(ex);
            db.SaveChanges();
            return RedirectToAction("Index");
       }
       return View(ex);
