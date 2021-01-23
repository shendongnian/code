    var orderType = typeof(Order);
    var param = Expression.Parameter(orderType);
    var member = orderType.GetMember(orderState).FirstOrDefault();
    if (member == null) 
    {
        /* requested member of "Order" does not exist */
    }
    var filter = Expression.Lambda<Func<Order, bool>>(  // "param => param.member != 0"
        Expression.NotEqual(                              // "param.member != 0"
            Expression.MakeMemberAccess(param, member),     // "param.member"
            Expression.Constant(0)),                        // "0"
        param);                                           // "param =>"
    query = _orderRepo.Table.Where(filter);
