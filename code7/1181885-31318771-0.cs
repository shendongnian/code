    public class MyModel
    {
        public decimal Price {get; set;}
        public string FormattedPrice 
        { get 
            {  return Price >= 10 
                    ? Price.ToString("#,#")
                    : Price.ToString("#,#.00");
            }
        }
    }  
