    query.OpenSubclause();
    query.WhereBetweenOrEqual(OrdersIndexFields.DeliveryInfo_DeliveryDateUtc,
    predicate.LocalDeliveryFrom.Value,
    predicate.LocalDeliveryTo.Value);
    
    query.OrElse().WhereBetweenOrEqual(OrdersIndexFields.EmptyOrderDoneDate,
    predicate.LocalDeliveryFrom.Value,
    predicate.LocalDeliveryTo.Value);
    query.CloseSubclause();
