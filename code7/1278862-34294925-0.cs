    public class CUSTOMER_ORDER {
      public CUSTOMER_ORDER() {}
      
      [Key(0)]
      public string OrderNumber {get;set;}
      public MPCCOM_SHIP_VIA ShipVia {get;set;}
    }
