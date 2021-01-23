    public ActionResult AssignSupplier(string supplierName, string UserName )
    {
        ApplicationUser user = db.Users.FirstOrDefault(u => u.UserName == UserName);
        Supplier supplier = db.Suppliers.FirstOrDefault(x => x.Name == supplierName);
        // Assign supplier to user
        user.Supplier = supplier;
        // Save
        db.SaveChanges();
    
        // ...
    }
