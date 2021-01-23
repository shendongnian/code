    var product = listOfProducts.FirstOrDefault(prod => prod.Id == id);
    if (product != null)
    {
        product.UnitInStocks = unitsInStocks;
        product.Price = price;
        Console.WriteLine("the product details has been changed");
    }
    else
    {
        Console.WriteLine("this product id does not exist");
    }
