    var result = invoicesDetails.GroupBy(id => id.Invoice.MemberId)
                                .Select(g => new {
                                           MemberOrCustomer = g.Key,
                                           Amount = g.Sum(x => x.Amount)
                                });
