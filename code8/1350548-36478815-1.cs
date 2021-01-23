            for (int i = 0; i < product.Count; i++)
                {
                     var DBModel = new Products();
                     DBModel.ProductName = product[i].ProductName;
                     DBModel.ProductPrice = product[i].ProductPrice;
                     db.Products.Add(DBModel);
                }
    
            db.SaveChanges();
