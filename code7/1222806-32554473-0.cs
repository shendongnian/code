    using (var _db = new products.Models.ProductContext())
    {
        var p = _db.Products.FirstOrDefault(x => x.ProductName == productName);
        if (p != null)
        {
            p.ViewCount = p.ViewCount + 1;
            _db.SaveChanges();
        }
    }
