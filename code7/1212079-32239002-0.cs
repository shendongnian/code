    class mimic:(the table class name)
    {
       (the table class name) tbl = new (the table class name)() ;
       new public string sku
       {
          get
          {
             return tbl.sku ;
          }
          set
          {
             tbl.sku = value ;
             tbl.sku = value ?? string.Empty ;
          }
       }
      new public string ProductNumber
       {
          get
          {
             return tbl.ProductNumber ;
          }
           //no need to set because as you said it wont set the productNumber
       }
       //get the origin table object and set it to its write place for further processes
    
       public (the table class name) getTheOrigin()
       {
          return this.tbl
       }
    }
 
 
