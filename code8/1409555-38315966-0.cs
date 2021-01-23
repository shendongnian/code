    var result = from s in db.Stkb_Sold
                 group s by s.StockCode into grp
                 orderby grp.Count() descending
                 select new
                 {
                     StockCode = grp.Key,
                     Qty = grp.Min(x => x.Qty),
                     TotalAmt= grp.Min(x => x.TotalAmt),,
                     DateAlloted= grp.Min(x => x.DateAlloted),,
                     Buy_Sold_Ind= grp.Min(x => x.Buy_Sold_Ind),
                     Posted = grp.Min(x => x.Posted),
                     Reversed = grp.Min(x => x.Reversed),
                     CustAID = grp.Min(a.CustAID)
                 };
