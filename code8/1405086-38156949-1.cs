     xOrders.ToList().ForEach((x) => {
         x.OrderItemDetails.ToList().ForEach(o => db.Entry(o).Reload());
         x.Dispatches.ToList().ForEach((D) => {
           D.DispatchItemDetails.ToList().ForEach(DI => db.Entry(DI).Reload());
           db.Entry(D).Reload();
         });
         db.Entry(x).Reload();
       });
