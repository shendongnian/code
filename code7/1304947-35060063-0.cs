    [HttpGet]
    public ViewResult Product_List()
    {
        ProductViewModel viewModelList = new ProductViewModel();
    
        viewModelList.LProducts = from products in db.AB_Product
                      where products.details == "Pending"
                      select products;
        
        return View(viewModelList);
    }
