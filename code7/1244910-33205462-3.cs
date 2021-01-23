	public static implicit operator InvoiceViewModel(InvoiceModel model)
	{
		return new InvoiceViewModel
		{
			InvoiceID = model.InvoiceID,
			Quantity = model.Quantity,
			Price = model.Price,
			Tax = model.Price * model.TaxRate
		};
	}
