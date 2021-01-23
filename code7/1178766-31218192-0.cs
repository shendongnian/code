    public List<Product> GetAllProductsByCategory(int ProductTypeId)
        {
                using (GarageEntities db = new GarageEntities()) 
                {
                    List<Product> products = db.Products.where(x=>x.ProductTypeID==ProductTypeId).toList()
                    return products;
                }  
    
        }
