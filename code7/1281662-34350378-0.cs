    public static bool In<T>(this T item, params T[] items) {
            return items.Any(i=> Equals(item, i));
    }
    
    GetAllAcountsForLoggedInAgents().Where( a => a.DispCode.In
      ("Deceased","DND","WN","WI","NC","NORESPONSE","SKIP","SHIFTED","SFU")
         ||  (a.DispCode.In("PTP,DIB,WCE,DP".Split(',')) &&
              a.PTPDate >= DateTime.Now)
         || (a.LastPaymentDate.Value.Month == 12 && a.LastPaymentDate.Value.Year == 2015)
