    q.Select(c => new 
                  { Invoices = c.SomeList.Sum(sl => sl.SomeValue),
                    Payments = c.OtherList.Sum(ol => ol.OtherValue)
                  }
    ).Select(x => new SomeObject
                  { Invoices = x.Invoices,
                    Payments = x.Payments,
                    Balance  = x.Payments - x.Invoices
                  });
