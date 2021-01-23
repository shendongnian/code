    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create([Bind(Include = "AppId,CustId,ManagerName,ManagerSurname")] Approval approval, string id)
    {
    var costumer = await db.Costumers.SingleAsync(x => x.CustId == id);
    if (ModelState.IsValid)
    {
        approval.CustId = id;
        CUSTOMER model = new CUSTOMER();
        model.CustActive = true;
        db.Entry(model).State = EntityState.Modified;
        db.Categories.Add(category);
        await db.SaveChangesAsync();
        return RedirectToAction("Index");
    }
    return View(approval);
}
 
 
            
