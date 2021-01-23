    public ActionResult ReceiveOrder(Address address)
    {
        EFDbContext context = new EFDbContext();
        context.Set<Addresses>().Attach(address);
        foreach(Product p in address.Products) {
            context.Set<Products>().Attach(p);
        }
        context.Entry(address).State = EntityState.Added; 
        context.SaveChanges();
        context.Dispose();
        return Json(new { success = true, responseText = "Okay" },
                JsonRequestBehavior.AllowGet);
    }
