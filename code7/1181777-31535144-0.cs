    public void gvProducts_UpdateItem(Int32 ProductID)
    {
        Product product = db.Products
                            .Include(it => it.TaxRate)
                            .Include(it => it.Category)
                            .Include(it => it.Brand)
                            .Include(it => it.Supplier)
                            .Include(it => it.Colour)
                            .FirstOrDefault(it => it.ProductID == ProductID);
        if (product == null)
        {
            ModelState.AddModelError("", String.Format("Item with id {0} was not found", ProductID));
            return;
        }
        ProductListModel model = Mapper.Map<ProductListModel>(product);
        TryUpdateModel(model);
        if (ModelState.IsValid)
        {
            Mapper.Map(model, product);
            db.SaveChanges();
            gvProducts.EditIndex = -1;
        }
    }
