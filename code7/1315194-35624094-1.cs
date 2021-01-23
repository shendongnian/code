	var brokerPaymentLists = dbContext.BrokerPayments
		.Include("PaymentDetail")
		.Where(bp => bp.IdPaymentStatus == (long)EntityModel.Additions.Variables.PaymentStatus.ALLOTED)
		.AsEnumerable()
		.GroupBy(bp => bp.IdBroker,
		(key, g) => new
		{
			IdBroker = key.Value,
			BrokerPayments = g
		});
