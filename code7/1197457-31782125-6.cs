	ticket.Attributes = model.Controls
		.OfType<IControlViewModel>()
		.Select(cvm => new TicketAttribute {
			Id = cvm.Id,
            Name = cvm.Name,
			Value = cvm.OutputValue
			})
		.ToList();
