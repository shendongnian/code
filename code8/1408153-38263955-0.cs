    public static IList GetAllCategoryData()
    {
         using (var objEntity = new BlueCouponEntities())
         {
           return (from TBL in objEntity.CategoryMasters.AsEnumerable()
                     let IIT = TBL.CategoryImageTransactions
                     select new
                     {
                     TBL.CategoryID,
                     TBL.CategoryName,
                     CategoryCount = objEntity.OfferCategoryMasters.Where(Lg => Lg.CategoryID == TBL.CategoryID && EntityFunctions.TruncateTime(Lg.OfferMaster.EndDate) > EntityFunctions.TruncateTime(DateTime.Now.Date)).Count(),
                     }
                 ).ToList();
         }
    }
