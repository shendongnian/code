    **Controller**
        var products = db.Products.Include("ProductCategory").ToList();
        return View(products);
    **View**
        @model IEnumerable<Namespace.To.Product>
        @foreach (var product in Model)
        {
            ...
        }
