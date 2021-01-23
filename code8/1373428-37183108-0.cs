    var prod = context.Products.FirstOrDefault(p => p.ProductID == ProductID);
    var prod2 = new Products();
    foreach (PropertyInfo pi in prod.GetType().GetProperties())
    {
    	prod2.GetType().GetProperties().First(p=>p.Name==pi.Name).SetValue(prod2, pi.GetValue(prod, null), null);
    }
    
    //prod2 is now a clone of prod. Make sure to adjust your product ID before adding the new product.
