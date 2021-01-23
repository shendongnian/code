	using PayPal.Api;
	// Authenticate with PayPal and setup the APIContext object.
	var config = ConfigManager.Instance.GetProperties();
	var accessToken = new OAuthTokenCredential(config).GetAccessToken();
	var apiContext = new APIContext(accessToken)
	{
		Config = config
	};
	// Get the payment history
	var paymentHistory = Payment.List(apiContext, count: 10, startIndex: 5);
