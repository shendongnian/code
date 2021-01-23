     using (var objEntity = new BlueCouponEntities())
     {
         DateTime now = DateTime.Now.Date;
         return (from TBL in objEntity.CategoryMasters.AsEnumerable()
                     let IIT = TBL.CategoryImageTransactions
                     select new
                     {
                     TBL.CategoryID,
                     TBL.CategoryName,
                     CategoryCount = objEntity.OfferCategoryMasters.Where(Lg => Lg.CategoryID == TBL.CategoryID && Lg.OfferMaster.EndDate > now).Count(),
                     }
                 ).ToList();   
    }
