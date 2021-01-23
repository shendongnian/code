    foreach (OrderItemDetail orderItemDetail in OrderItemDetailClient.GetOrderItemDetailsForOrderId(NewOrder.OrderId))
    {
        OrderItemDetailClient.DeleteOrderItemDetail(orderItemDetail);
    }
    foreach (Dispatch dispatch in DispatchClient.GetDispatchesForOrderId(NewOrder.OrderId))
    {
        foreach (DispatchItemDetail dispatchItemDetail in DispatchItemDetailClient.GetDispatchItemDetailsForInvoiceId(dispatch.InvoiceId))
        {
            DispatchItemDetailClient.DeleteDispatchItemDetail(dispatchItemDetail);
        }
        DispatchClient.DeleteDispatch(dispatch);
    }
    OrderClient.UpdateOrder(NewOrder);
