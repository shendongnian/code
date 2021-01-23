    class Shop
    {
      public double GetPrice(List<IProduct> products)
      {
        return products.Sum(x => x.GetPrice());
      }
    }
    
    interface IProduct { double GetPrice(); };
    class Pizza : IProduct 
    { 
      double GetPrice () 
      { 
        return 5.0;//Get the price here.
      }
    }
