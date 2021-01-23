    public class Price {
       public decimal Pence { get; set; }
       
       [NotMapped]
       public decimal Pounds => Pence == 0 ? 0 : Pence/100;
    }
