    var pop = from po in ctx.PurchaseOrders
              select new SearchItem
              {
               id = po.PurchaseOrderID,
                label = po.SupplierID,
                 category = po.purchaseorder
               }.AsEnumerable()  // Now, following Select will operate in memory
               .Select(n => new {
               n.PurchaseOrderID,
               SupplierID = t.SupplierID ?? t.SupplierID.ToString(),
               n.puchaseorder
     }).ToList();
