    var totals = DbContext.PaymentCertificates
                    .Include("ValuationItems.Cost")
                    .Select(c => new {
                        Total = c.ValuationItems.Sum(x => x.Cost.Price*x.ValuationQuantity)
                    });
