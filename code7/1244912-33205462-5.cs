	public InvoiceViewModel(InvoiceModel model)
	{
		InvoiceID = model.InvoiceID;
		Quantity = model.Quantity;
		Price = model.Price;
		Tax = model.Price * model.TaxRate;
	}
