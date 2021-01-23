        q.Select(c =>
                    {
                        var invoices = c.SomeList.Sum(sl => sl.SomeValue);
                        var payments = c.OtherList.Sum(ol => ol.OtherValue);
                        // do stuff
                        return new SomeObject
                        {
                            Invoices = invoices,
                            Payments = payments,
                            Balance = payments - invoices
                        };
                    });
