     try
     {
       var str = from a in db.ProductStatisticsTemp select a;
      
       //This will improve some performance
       db.Configuration.AutoDetectChangesEnabled = false;
    
       foreach (var val in str.ToList())
       {                     
          ProductStatistics ls = new ProductStatistics
          {
             
             Product_ID = val.Product_ID,
             ProductNameEn = val.ProductNameEn,
             ProductNameAr = val.ProductNameAr
         };
    
         //use AddRange or Add based on your EF Version.
         db.ProductStatistics.Add(ls);
       }
    
      db.SaveChanges();
     }
     finally
     {
          db.Configuration.AutoDetectChangesEnabled = true;
     }
