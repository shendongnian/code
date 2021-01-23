    public class Invoice
    {
         public string TF { get; set; }
         public string BF { get; set; }
         public string MD { get; set; }
         public string EFM { get; set; }
         public string ATT { get; set; }
         public string FPK { get; set; }
     }
     public class Example
     {
         public Invoice Invoice { get; set; }
         public string TF { get; set; }
     }
     public class RootObject
     {
         public List<Example> Example { get; set; }
     }
