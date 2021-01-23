    [HttpGet]
    public ViewResult Product_List()
    {
        ProductViewModel viewModelList = new ProductViewModel();
        viewModelList.LProducts = (from products in db.Product
                      where products.details == "Pending"
                      select products).ToList();
        return View(viewModelList);
    }
