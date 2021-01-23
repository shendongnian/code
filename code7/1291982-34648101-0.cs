    public class ContactNumber
    {
      public string MobileNo {get;set;}
      public string LandNo {get; set;}
      public string ContacNo { get {retun MobileNo +','+ LandNo;}}
    }
