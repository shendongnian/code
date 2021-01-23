	var notificationPolicy = _container.AddNewExtension<Interception>()
		.RegisterType<BaseViewModel, RfidData>()
		.Configure<Interception>()
		.SetDefaultInterceptorFor(userControlType, new VirtualMethodInterceptor())
		.AddPolicy("NotificationPolicy");
	notificationPolicy.AddMatchingRule(new PropertyMatchingRule("*", PropertyMatchingOption.Set));
	notificationPolicy.AddCallHandler<PropertyChangedCallHandler>();
