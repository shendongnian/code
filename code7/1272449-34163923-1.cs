    public ActionResult ProductsMenu()
    {
        var listOfAvailableProducts = GetAvialableProducts(Principal); //to implement elsewhere
        var productsMenuItems = new List<ProductMenuItem>();
    
        for(var i in listOfAvailableProducts)
        {
            productsMenuItems.Add(new ProductMenuItem
                {
                    Id = i.id,
                    Name = i.name,
                    Url = "//example.com/there"
                }
            );
        }
    
        return PartialView("/path/to/_ProductsMenu.cshtml", productsMenuItems);
    }
