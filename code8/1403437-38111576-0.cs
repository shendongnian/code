    Orders = new ObservableCollection<ClaimDTO>(from order in db.Orders
                                                from goodItems in db.Items
                                                from orderItemDetail in order.OrderItemDetails
                                                from dispatch in order.Dispatches
                                                from dispatchItemDetail in dispatch.DispatchItemDetails
                                                where ((orderItemDetail.ItemId == dispatchItemDetail.ItemId && dispatchItemDetail.Rate > orderItemDetail.Rate)
                                                        && (dispatch.DateOfDispatch >= StartDate && dispatch.DateOfDispatch <= EndDate))
                                                select new ClaimDTO
                                                {
                                                    SalesOrderId = order.SalesOrderId,
                                                    DateOfOrder = order.DateOfOrder,
                                                    PartyName = order.Party.PartyName,
                     ------------>                  OrderItemName = goodItems.Where(x => x.ItemId == orderItemDetail.ItemId).FirstOrDefault().ItemName,
                                                    OrderQuantity = orderItemDetail.Quantity,
                                                    OrderRate = orderItemDetail.Rate,
                                                    OrderAmount = orderItemDetail.Amount,
                                                    SalesInvoiceId = dispatch.SalesInvoiceId,
                                                    DateOfDispatch = dispatch.DateOfDispatch,
                     ------------>                  DispatchItemName = goodItems.Where(x => x.ItemId == dispatchItemDetail.ItemId).FirstOrDefault().ItemName,
                                                    DispatchQuantity = dispatchItemDetail.Quantity,
                                                    DispatchRate = dispatchItemDetail.Rate,
                                                    DispatchAmount = dispatchItemDetail.Amount
                                                });
    return Orders;
