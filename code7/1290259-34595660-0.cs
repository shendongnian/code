    if (ModelState.IsValid)
    {
        db.Customers.Attach(customers);
        var entry = db.Entry(customers);
        entry.Property(e => e.customerid).IsModified = true;
        entry.Property(e => e.firstname).IsModified = true;
        ...
        await db.SaveChangesAsync();
        return RedirectToAction("Index");
    }
