	@foreach (var customer in Model)
	{
		var businessCustomer = customer as Models.BusinessCustomer;
		if (businessCustomer != null)
		{
			@businessCustomer.VatNumber
		}
		
		var privateCustomer = customer as Models.PrivateCustomer;
		if (privateCustomer != null)
		{
			@privateCustomer.Cpr
		}
	}
