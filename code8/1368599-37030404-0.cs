    var customerCallVM = new CustomerCallVM
    {
        Id = customerCall.Id,
		CustomerName = customerCall.CustomerName,
        // ...
		CallStatus = new CallStatusVM
		{
			Id = customerCall.CallStatus.Id,
			StatusName = customerCall.CallStatus.StatusName,
		}
    };
