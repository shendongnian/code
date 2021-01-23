    public ActionResult Contact()
    {
        Contact dane = null;
        using (ImportEntities ctx = new ImportEntities())
        {
            ctx.Connection.Open;
            dane = Entity.Contact.FirstOrDefault()
            ctx.Connection.Close;
        }
        return View("Contact",dane);
    }
