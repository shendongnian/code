    public void SaveProduct(PRODUCT product)
    {
       using(PizzaLoungeEntities db = new PizzaLoungeEntities())
        {
            db.PRODUCTs.Add(product);
            if( db.SaveChanges() ==1)
            {
                // Here your data has been saved
            }
        }    
     }
