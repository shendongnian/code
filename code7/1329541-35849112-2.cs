		var clients = (from client in _clientService.GetAllClients()
						let minDate = DateTime.MinValue
						let lastRequisitionDate = (DateTime)client.LastRequisitionDate
						let lastDeliveryDate = (DateTime)client.LastDeliveryDate
						let lastDelivery = (DateTime)client.LastDelivery
						where lastRequisitionDate != minDate && lastDelivery != minDate && client.Inactive != 0 && (lastDelivery - lastRequisitionDate).Days < 9 && (lastDelivery - lastRequisitionDate).Days >= 0
						select client).ToList();
