    Orders = new ObservableCollection<Order>(
		from o in orderService.GetAllOrders
		from d in o.Dispatches
		from t in d.DispatchItemTransactions
		select new Order
		{
			OrderId = o.OrderId,
			DateOfOrder = o.DateOfOrder,
			PartyName = o.PartyName,
			Dispatches = new List<Dispatch> 
			{ 
				new Dispatch
				{
					InvoiceNo = d.InvoiceNo
					DateOfDispatch = d.DateOfDispatch
					DispatchItemTransactions = new List<DispatchItemTransaction> { t }
				}
			}			
		});
