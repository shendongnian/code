    using (YourContext db = new YourContext())
     {
                db.OrderLines.Attach(orderLine);  // added this part
                db.OrderLines.DeleteObject(orderLine);
                db.SaveChanges();   
      }
   
