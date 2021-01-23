    var orderType = typeof(Order);
    var param = Expression.Parameter(orderType);
    var member = Expression.PropertyOrField(param, orderState); // may throw ArgumentException!
    var filter = Expression.Lambda<Func<Order, bool>>(
        Expression.NotEqual(member, Expression.Constant(0)),
        param);
    query = _orderRepo.Table.Where(filter);
