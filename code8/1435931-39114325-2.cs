    allclient = (from ....
                 select new AllClient()
                 {
                  ...
                  //PurchaseDT = String.Format(...),
                  PurchaseDate = k.PurchaseDate, //the formatting will be done later
                 }
    foreach (AllClient c in allclient)
          c.PurchaseDT = String.Format("{0:y yy yyy yyyy}", c.PurchaseDT); //or whatever other formatting you want
