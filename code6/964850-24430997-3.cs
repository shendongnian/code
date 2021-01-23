    Lots = session.Query<Lot>().ToList();
    IncomingPayments = session.Query<IncomingPayment>().ToList();
    var result = Lots.Join(IncomingPayments, 
                           x=>x.IncomingPayment,  
                           y=>y.Id,
                           (x,y) => new
                           {
                               Address = x.ToToAddress,
                               OutCome = y.Outcome
                           }).GroupBy(x => x.Address, 
                                      x => x.Outcome,
                                      (kew, group) =>
                                      {
                                          Address = key,
                                          SumAmount = group.Sum()
                                      });    
   
                          
