    public class YourClassName {
       public decimal Price { get; set; }
       
       [NotMapped]
       public decimal Pounds => Price/100;
    }
