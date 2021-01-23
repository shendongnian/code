    if (file.State == EntityState.Deleted)
    {
        var text = "File Deleted: " + file.Entity.FriendlyFileName;
        var productEntry = ChangeTracker.Entries<Product>()
                                        .FirstOrDefault(p => p.Entity.ID == file.ProductID);
        if (productEntry != null)
        {
            var updatedProduct = new Update { Product = productEntry.Entity, UpdateDateTime = DateTime.Now, UpdateText = text, User = HttpContext.Current.Request.LogonUserIdentity.Name };
            Updates.Add(updatedProduct);
        }
    }
