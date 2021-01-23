    using (var ctx = new DatabaseEntities())
    {
       long t;
      if(!ctx.CustomerInboxes.Any(m=>m.CustomerId == customerId
       && m.Reference == item.ShoppingCartWebId.ToString() 
       && m.SubjectId == HerdbookConstants.PendingCartMessage 
       && (item.ShoppingCartWebId.length > SqlFunctions.StringConvert((long).Reference) 
       || (item.ShoppingCartWebId.length == SqlFunctions.StringConvert((long).Reference
           && item.ShoppingCartWebId > SqlFunctions.StringConvert((long)m.Reference)
     ))){
         //do something special
       }
    }
