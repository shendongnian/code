    [HttpGet]
    public ActionResult Delete()
    {
        return View();
    }
    [HttpPost]
    public ActionResult Delete(string RoleName)
    {
        var thisRole = context.Roles.Where(r => r.Name.Equals(RoleName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
        context.Roles.Remove(thisRole);
        context.SaveChanges();
        return RedirectToAction("Index");
    }
