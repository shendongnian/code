    using (var context = new dataEntities())
    {
        context.Entry(vessel).State = EntityState.Added;
        context.Entry(vessel_spec).State = EntityState.Added;                               
        context.SaveChanges();
        return RedirectToAction("Index");
    }
