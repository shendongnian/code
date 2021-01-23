    var yesterday = DateTime.Today.AddDays(-1);
    var tomorrow = DateTime.Today.AddDays(1);
    
    var agencyPayment = from y in db2.vw_Agency_Payment
                        join t in db2.vw_Agency_Payment on y.UserName equals t.UserName
                        where y.PaymentDate.Date = yesterday
                           && t.PaymentDate.Date = DateTime.Today
                        select new AgencyPaymentModel
                                   {
                                       agencyUserCode = y.UserName,
                                       yesterdayPayment = y.PaymentAmount,
                                       todayPayment = t.PaymentAmount,
                                       growth = (t.PaymentAmount - y.PaymentAmount) / y.PaymentAmount * 100
                                   };
    
    return View(agencyPayment.OrderByDescending(c => c.growth).Take(100).ToList());
