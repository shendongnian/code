    using (var ctx = new DatabaseEntities())
    {
       long t;
      if(!ctx.CustomerInboxes.ToList().Any(m=>m.CustomerId == customerId
       && m.Reference == item.ShoppingCartWebId.ToString() 
       && m.SubjectId == HerdbookConstants.PendingCartMessage 
       && item.ShoppingCartWebId > (long.TryParse(m.Reference,out t)? t : long.MaxValue)))
     )){
         //do something special
      }
    }
