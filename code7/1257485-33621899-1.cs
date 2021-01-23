    var productFound = false;
    foreach (Product item in listOfProducts)
    {
        if (item.Id == id)
        {
            productFound = true;
            item.UnitInStocks = unitsInStocks;
            item.Price = price;
            Console.WriteLine("the product details has been changed");
            break;
        }    
    }
    
    if (!productFound)
    {
        Console.WriteLine("this product id does not exist");
    }
