    public class TempProduct 
    {
      public Price price {get; set;}
      public Order order {get; set;}
      
      public class Price
      {
      	public string price {get; set;}
    	public string avgprice {get; set;}
    	public string maxprice {get; set;}
      }
      
      public class Order
      {
      	public string orderType1 {get; set;}
    	public string orderType2 {get; set;}
    	public string orderType3 {get; set;}
      }
    }
