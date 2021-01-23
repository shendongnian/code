    public class Product
    {
      private PriceCalculator Calculator {get;set;}
      public decimal Price{get {return Calculator.GetPrice();}}
    
      public Product(int factor)
      {
        Calculator=new PriceCalculator(factor);
      }
    }
