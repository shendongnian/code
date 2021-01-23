    public ActionResult ReceiveOrder(Address address)
    {
        EFDbContext context = new EFDbContext();
        Product p = new Product { ProductId = address.First().ProductId };
        context.Set<Product>().Attach(p);
        address.Products.Clear();
        p.Addresses.Add(address);
        context.SaveChanges();
        context.Dispose();
        return Json(new { success = true, responseText = "Okay" },
                JsonRequestBehavior.AllowGet);
    }
