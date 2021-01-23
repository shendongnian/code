	var query =
		_requests
			.SelectMany(request =>
				_mainResponses.Where(m => m.Id == request.Id).Take(1)
					.Do(m => OnMainResponseReceived(m))
					.Zip(
						_secondaryResponses.Where(s => s.Id == request.Id).Take(1),
						(m, s) => new MainAndSecondaryResponseReceived()
						{
						    Request = request,
						    Main = m, 
						    Secondary = s
						}));
							
	var subscription =
		query.Subscribe(x => OnMainAndSecondaryResponseReceived(x));
