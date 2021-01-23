    public static object ToAnonymousType(this Address address)
    {
        var products = address.Products.Select(p => p.ToAnonymousType());
        return new { Id = address.Id, Products=products };
    }
    
    public static object ToAnonymousType(this Product product)
    {
        return new { Id = product.Id };
    }
    
    public JsonResult GetAllOrders()
    {
        using(var context = new EFDbContext())
        {
            var addresses = context.Addresses.Include(a => a.Products).ToList().Select(a => a.ToAnonymousType());
            return Json(addresses, JsonRequestBehavior.AllowGet);
        }
    }
