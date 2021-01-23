    public IEnumerable<ClassName> GetOrders()
    {
       var orders = memberOrders.Join(members, 
                                      x => x.MemberID, 
                                      y => y.MemberID, 
                                     (x,y) => new ClassName 
                                     { 
                                         Order = x,
                                         MemberName = y.MemberName 
                                     }).OrderByDescending(x => x.Order.MailingDate);           
        return orders;
    }
