    public ActionResult JoinSupToPro()
    {
        SupplierDBContext dbS = new SupplierDBContext();
        //Create list instance of your model
        List<ProductSupplier> model=new List<ProductSupplier>();
        var innerJoinQuery = (from pro in db.Products 
                             join sup in dbS.Suppliers 
                             on pro.SupplierId equals sup.ID
                             select new 
                             { 
                                 proName=pro.Name,
                                 proPrice=pro.Price,  
                                 supName= sup.Name , 
                                 supPhone=sup.Phone
                             }).ToList();//convert to List
        foreach(var item in innerJoinQuery) //retrieve each item and assign to model
        {
              model.Add(new ProductSupplier()
              {
                    ProName = item.proName,
                    Price = item.proPrice,
                    SupName = item.supName,
                    SupPhone = item.supPhone
              });
        }
        return View(model);
    }
