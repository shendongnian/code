    Orders = new ObservableCollection<Order>(
		from o in orderService.GetAllOrders
		from d in o.Dispatches
		from dd in d.DispathDetails
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
					DispatchDetails = new List<DispatchDetail> { dd }
				}
			}			
		});
