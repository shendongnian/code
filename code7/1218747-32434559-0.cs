    public class ResultProducts 
        {
           
                public int Quantity { get; set; }
                public string ProductDesc { get; set; }
                public int  RemainingQuantity { get; set; }
                public int QtyInHand { get; set; }
         }
    public IQueryable<ResultProducts> GetProductsByShipID(int id)
            {
                var oppProductss =from c in db.OpportunityProducts
                                  from p in db.Products
                                  where p.ProductID == c.ProductID
                                  select new ResultProducts()
                                  { 
                                   Quantity =c.Quantity,
                                   ProductDesc= c.ProductDesc,
                                   RemainingQuantity=c.RemainingQuantity,
                                   QtyInHand=p.QtyInHand 
                                   };
                
                return oppProductss ;
            }
