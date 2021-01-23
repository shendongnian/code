    public ActionResult actionname(datatype yourclassname)
    {
    db.Entry(yourclassname).State = System.Data.Entity.EntityState.Added;
    db.savechanges();
    }
