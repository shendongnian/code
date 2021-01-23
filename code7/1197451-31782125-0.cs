	ticket.Attributes = model.Controls
		.OfType<IInputViewModel>()
		.Select(x => new TicketAttribute {
			Id = cvm.Id,
            Name = cvm.Name,
			Value = x.Value
			})
		.ToList();
