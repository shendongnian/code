    public class BillLine
    {
       public int DiscountValue { get; set; }
       public Article Article {get; set; }
    }
    
    public class Bill
    {
        public List<BillLine> Lines { get; set;}
        public int Total { get 
        {
           int result;
           foreach var line in Lines {
               //Update result with your calculations 
           }
           return result;
        }
       }
    }
