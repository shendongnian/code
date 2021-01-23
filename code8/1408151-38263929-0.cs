    using (var objEntity = new BlueCouponEntities())
    {
        return (from TBL in objEntity.CategoryMasters.AsEnumerable()
                     let IIT = TBL.CategoryImageTransactions
                     select new
                     {
                     TBL.CategoryID,
                     TBL.CategoryName,
                     CategoryCount = objEntity.OfferCategoryMasters.Where(Lg => Lg.CategoryID == TBL.CategoryID && Lg.OfferMaster.EndDate > EntityFunctions.TruncateTime(DateTime.Now)).Count(),
                     }
                 ).ToList();
    }
