    protected void UpdateCategoryWithProducts(Category entity)
    {
        /*--- Get Original Entity ---*/
        var originalMaster = this.GetQuery("Products").Where(x => x.CategoryId == entity.CategoryId).FirstOrDefault();
        /*--- Master ---*/
        this.Context.ChangeEntityStateToEdited(originalMaster, entity);
        if (entity.Products != null)
        {
            /*--- Get Lists ---*/
            var addedList = entity
                .Products
                .Where(y => y.ProductId == 0)
                .ToList();
            var deletedList = originalMaster
                .Products
                .Where
                (
                    x =>
                    (
                        !entity.Products
                        .Select(y => y.ProductId)
                        .Contains(x.ProductId)
                    )
                )
                .ToList();
            var editedList = entity.Products
             .Where
             (
                 y => originalMaster
                 .Products
                 .Select(z => z.ProductId)
                 .Contains(y.ProductId)
              )
              .ToList();
            /*--- Delete ---*/
            deletedList.ForEach(deletedProduct =>
            {
                originalMaster.Products.Remove(deletedProduct);
                this.Context.ChangeEntityStateToDeleted(deletedProduct);
            });
            /*--- Edit ---*/
            editedList.ForEach(editedProduct =>
            {
                var originalProduct = originalMaster.Products.Where(x => x.ProductId == editedProduct.ProductId).FirstOrDefault();
                this.Context.ChangeEntityStateToEdited(originalProduct, editedProduct);
            });
            /*---  Add ---*/
            addedList.ForEach(addedProduct =>
            {
                originalMaster.Products.Add(addedProduct);
            });
        }
        /*--- Save in context ---*/
        this.Context.Categories.Update(originalMaster);
        this.Context.SaveChanges();
    }
