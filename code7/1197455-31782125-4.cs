	ticket.Attributes = model.Controls
		.OfType<IControlViewModel>()
		.Select(x => new TicketAttribute {
			Id = cvm.Id,
            Name = cvm.Name,
			Value = x.OutputValue
			})
		.ToList();
