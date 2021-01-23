	public ActionResult Download(Guid customerOrderId)
	{
		var order = this.UnitOfWork.GetRepository<CustomerOrder>().Get(customerOrderId);
		var csv = new StringBuilder();
		csv.AppendLine("Customer,Bill To Name,Ship To Name,Patient,Order#,Order Date," +
			"Line,Item#,Item Description,Qty,UOM,Price,Ext Price,Carrier," +
			"Notes,Purchase Order");
		
		foreach (var cartLine in order.OrderLines)
		{
			//Customer,Bill To Name,Ship To Name,Patient,Order#,Order Date," + 
			//"Line,Item#,Item Description,Qty,UOM,Price,Ext Price,Carrier," +
			//"Notes,Purchase Order
			
			csv.AppendLine(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15}",
				order.CustomerNumber, order.BTDisplayName, order.ShipTo.CustomerName, "", order.OrderNumber, order.OrderDate, cartLine.Line, cartLine.Product.ProductCode, cartLine.Description,
				cartLine.QtyOrdered, cartLine.UnitOfMeasure, cartLine.ActualPriceDisplay, cartLine.ExtendedActualPriceDisplay, order.ShippingDisplay, order.Notes, order.CustomerPO));
		}
		csv.AppendLine();
		csv.AppendLine("Subtotal,Shipping & Handling,Tax,Total");
		csv.AppendLine(string.Format("{0},{1},{2},{3}", order.OrderSubTotalDisplay, order.ShippingAndHandling, order.TotalSalesTaxDisplay, order.OrderGrandTotalDisplay));
		var filename = "MSD-Order-" + orderNum + ".csv";  
		
		using (StreamWriter sw = File.CreateText(Server.MapPath("~/files/" + filename)) 
		{
			sw.Write(csv.ToString());
		} 
		// adjust your url accordingly to match the directory to which you saved
        // '/files/' corresponds to where you did the File.CreateText
        // returning Content in an ActionResult defaults to text
		return Content("http://foo.com/files/" + filename);
	}
