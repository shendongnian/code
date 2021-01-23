    var products = db.Products.AsNoTracking().Include(p => p.Category);
    var setting = new JsonSerializerSettings
    {
        Formatting = Newtonsoft.Json.Formatting.Indented, // Just for humans
        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
    };
    var json = JsonConvert.SerializeObject(products, setting);
